using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OldHome.Core;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        var inventoryOutbound = _map.Map<InventoryOutbound>(createdOutbound); // 映射到出库单
                        var resOutbound = await _db.InventoryOutbounds.AddAsync(inventoryOutbound);
                        foreach (var item in resOutbound.Entity.Items)
                        {
                            var mi = _db.MedicineInventories
                                .Where(p => p.MedicineId == item.MedicineId && p.ResidentId == item.ResidentId && p.QtyRemaining > 0)
                                .OrderBy(p => p.BatchNumber)
                                .First();
                            if (mi.QtyRemaining >= item.ActualQuantity)
                            {
                                mi.QtyRemaining -= item.ActualQuantity;
                                _db.MedicineInventories.Update(mi);
                            }
                            else
                            {

                            }
                        }
                    }
                    await _db.SaveChangesAsync();
                    await transaction.CommitAsync();
                    return createdOutbound.Entity;
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
