using OldHome.DTO;
using OldHome.Entities;
using Microsoft.EntityFrameworkCore;

namespace OldHome.Service.Endpoints
{
    public static class MedicineInventoryEndpoints
    {
        public static void MapMedicineInventoryEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("medicine-inventories");

            EndpointsHelper.GetPage<MedicineInventoryDto, MedicineInventory>(group, [q => q.Include(p => p.Resident), q => q.Include(p => p.Medicine)]);
            EndpointsHelper.Create<MedicineInventoryCreate, MedicineInventory, MedicineInventoryDto>(group);
            EndpointsHelper.Modify<MedicineInventoryModify, MedicineInventory>(group);
            EndpointsHelper.Delete<MedicineInventory>(group);
        }
    }
}
