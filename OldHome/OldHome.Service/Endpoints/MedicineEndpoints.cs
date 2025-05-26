using OldHome.DTO;
using OldHome.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OldHome.Service.Endpoints
{
    public static class MedicineEndpoints
    {
        public static void MapMedicineEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("medicines");

            EndpointsHelper.GetPage<MedicineDto, Medicine>(group);
            EndpointsHelper.GetAll<MedicineDto, Medicine>(group);
            EndpointsHelper.GetAllSamples<MedicineSample, Medicine>(group);
            EndpointsHelper.GetTop10Samples<MedicineSample, Medicine>(group);

            EndpointsHelper.Create<MedicineCreate, Medicine, MedicineDto>(group);
            EndpointsHelper.Modify<MedicineModify, Medicine>(group);
            EndpointsHelper.Delete<Medicine>(group);
        }
    }
}
