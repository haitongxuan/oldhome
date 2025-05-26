using OldHome.DTO;
using OldHome.Entities;
using Microsoft.EntityFrameworkCore;

namespace OldHome.Service.Endpoints
{
    public static class MedicineTransactionLogEndpoints
    {
        public static void MapMedicineTransactionLogEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("medicine-transaction-logs");

            EndpointsHelper.GetPage<MedicineTransactionLogDto, MedicineTransactionLog>(group, [q => q.Include(p => p.Resident), q => q.Include(p => p.Medicine)]);
            EndpointsHelper.Create<MedicineTransactionLogCreate, MedicineTransactionLog, MedicineTransactionLogDto>(group);
            EndpointsHelper.Modify<MedicineTransactionLogModify, MedicineTransactionLog>(group);
            EndpointsHelper.Delete<MedicineTransactionLog>(group);
        }
    }
}
