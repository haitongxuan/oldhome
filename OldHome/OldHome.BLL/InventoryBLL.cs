using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OldHome.Core;
using OldHome.DAL;
using OldHome.Entities;

namespace OldHome.BLL
{
    public class InventoryBLL
    {
        private readonly AppDataContext _db;
        private readonly IMapper _map;
        public InventoryBLL(AppDataContext db, IMapper map)
        {
            _db = db;
            _map = map;
        }

        public async Task<FamilyMedicineDelivery> CreateFamilyMedicineDeliveryAsync(FamilyMedicineDelivery delivery)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var createdDelivery = await _db.FamilyMedicineDeliveries.AddAsync(delivery);
                    if (delivery.Status.Equals(DeliveryStatus.Stored))
                    {
                        var inbound = _map.Map<InventoryInbound>(createdDelivery); // 映射到入库单
                        var resInbound = await _db.InventoryInbounds.AddAsync(inbound);
                        foreach (var item in resInbound.Entity.Items)
                        {
                            var mi = _map.Map<MedicineInventory>(item);
                            await _db.MedicineInventories.AddAsync(mi);
                        }
                    }
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return createdDelivery.Entity;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task DeleteFamilyMedicineDeliveryAsync(FamilyMedicineDelivery delivery)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    _db.FamilyMedicineDeliveries.Remove(delivery);
                    var inbound = await _db.InventoryInbounds
                        .FirstOrDefaultAsync(i => i.SourceInfo == delivery.DeliveryNumber);
                    if (inbound != null)
                    {
                        _db.InventoryInbounds.Remove(inbound);
                        foreach (var item in inbound.Items)
                        {
                            var inventory = await _db.MedicineInventories
                                .FirstOrDefaultAsync(mi => mi.MedicineId == item.MedicineId && mi.OrgId == delivery.OrgId);
                            if (inventory != null)
                            {
                                _db.MedicineInventories.Remove(inventory);
                            }
                        }
                    }
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        public async Task<MedicationOutbound> CreateMedicationOutboundAsync(MedicationOutbound outbound)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var createdOutbound = await _db.MedicationOutbounds.AddAsync(outbound);
                    if (outbound.Status.Equals(OutboundStatus.Completed))
                    {
                        // 创建对应的库存出库单
                        var inventoryOutbound = new InventoryOutbound
                        {
                            OutboundType = OutboundType.Dispensing, // 发药类型
                            OutboundDate = outbound.OutboundDate,
                            OrgId = outbound.OrgId,
                            Status = OutboundStatus.Completed,
                            OutboundById = outbound.PharmacistId,
                            Notes = $"发药单号：{outbound.OutboundNumber}",
                            CreatedAt = DateTime.UtcNow,
                            CreatedBy = outbound.CreatedBy,
                            Items = new List<InventoryOutboundItem>()
                        };
                        foreach (var item in outbound.Items)
                        {
                            var inventories = await _db.MedicineInventories
                                .Where(mi => mi.MedicineId == item.MedicineId
                                  && mi.OrgId == outbound.OrgId
                                  && mi.QtyRemaining > 0
                                  && mi.Status == MedicineInventoryStatus.Normal
                                  && mi.ExpirationDate > DateOnly.FromDateTime(DateTime.UtcNow)) // 排除过期药品
                                .OrderBy(mi => mi.BatchNumber) // FIFO: 按批次号排序（通常批次号包含日期信息）
                                .ToListAsync();
                            // 如果是住户专用药品，需要额外过滤
                            if (!outbound.IsFromPublicInventory)
                            {
                                inventories = inventories
                                    .Where(mi => mi.ResidentId == item.ResidentId)
                                    .ToList();
                            }
                            else
                            {
                                // 公共药品库存
                                inventories = inventories
                                    .Where(mi => !mi.ResidentId.HasValue)
                                    .ToList();
                            }
                            // 计算实际需要的数量（转换为最小单位）
                            var requiredQuantity = item.ActualQuantity;
                            var remainingQuantity = requiredQuantity;
                            foreach (var inventory in inventories)
                            {
                                if (remainingQuantity <= 0) break;

                                // 计算本批次可以扣减的数量
                                var deductQuantity = Math.Min(inventory.QtyRemaining, remainingQuantity);
                                // 创建库存出库明细
                                var outboundItem = new InventoryOutboundItem
                                {
                                    InventoryId = inventory.Id,
                                    MedicineId = item.MedicineId,
                                    ResidentId = item.ResidentId,
                                    BatchNumber = inventory.BatchNumber,
                                    RequestedQuantity = deductQuantity,
                                    ActualQuantity = deductQuantity,
                                    UnitCost = 0, // 可以根据入库成本计算
                                    TotalCost = 0,
                                    ExpirationDate = inventory.ExpirationDate,
                                    Notes = $"发药给住户：{item.Resident?.Name}",
                                    CreatedAt = DateTime.UtcNow,
                                    CreatedBy = outbound.CreatedBy
                                };

                                inventoryOutbound.Items.Add(outboundItem);
                                // 扣减库存
                                inventory.QtyRemaining -= deductQuantity;
                                inventory.UpdatedAt = DateTime.UtcNow;
                                inventory.UpdatedBy = outbound.CreatedBy;
                                // 如果库存已用完，更新状态
                                if (inventory.QtyRemaining == 0)
                                {
                                    inventory.Status = MedicineInventoryStatus.UsedUp;
                                }
                                _db.MedicineInventories.Update(inventory);

                                // 更新剩余需求量
                                remainingQuantity -= deductQuantity;
                            }
                            // 检查是否有足够的库存
                            if (remainingQuantity > 0)
                            {
                                throw new InvalidOperationException(
                                    $"药品 {item.Medicine.Name} 库存不足，" +
                                    $"需要 {requiredQuantity} {item.Medicine.MinUnit}，" +
                                    $"但只有 {requiredQuantity - remainingQuantity} {item.Medicine.MinUnit} 可用。");
                            }

                        }
                        // 计算总金额
                        inventoryOutbound.TotalAmount = inventoryOutbound.Items.Sum(i => i.TotalCost);

                        // 保存库存出库单
                        await _db.InventoryOutbounds.AddAsync(inventoryOutbound);
                    }
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return createdOutbound.Entity;
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception($"创建发药出库单失败：{ex.Message}", ex);
                }
            }
        }
    }
}
