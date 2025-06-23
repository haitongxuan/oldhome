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
        private readonly AppDataContext db;
        public FamilyMedicineDeliveryBLL(AppDataContext db)
        {
            this.db = db;
        }

        public async Task<FamilyMedicineDelivery> CreateDeliveryAsync(FamilyMedicineDelivery delivery)
        {
            using (var transaction = await db.Database.BeginTransactionAsync())
            {
                try
                {
                    var createdDeliveryEntry = await db.FamilyMedicineDeliveries.AddAsync(delivery);
                    await db.SaveChangesAsync(); // Ensure the changes are saved to the database  
                    await transaction.CommitAsync();
                    return createdDeliveryEntry.Entity; // Access the Entity property to return the actual entity  
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
