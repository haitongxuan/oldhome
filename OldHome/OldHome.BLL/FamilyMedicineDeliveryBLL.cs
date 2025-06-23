using AutoMapper;
using OldHome.Core;
using OldHome.DAL;
using OldHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.BLL
{
    public class FamilyMedicineDeliveryBLL
    {
        private readonly AppDataContext _db;
        private readonly IMapper _map;
        public FamilyMedicineDeliveryBLL(AppDataContext db)
        {
            this._db = db;
        }

        public async Task<FamilyMedicineDelivery> CreateDeliveryAsync(FamilyMedicineDelivery delivery)
        {
            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    var createdDelivery = await _db.FamilyMedicineDeliveries.AddAsync(delivery);
                    if (delivery.Status.Equals(DeliveryStatus.Stored))
                    {
                        _map.Map<>
                        _db.InventoryInbounds.Add()
                    }
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
    }
}
