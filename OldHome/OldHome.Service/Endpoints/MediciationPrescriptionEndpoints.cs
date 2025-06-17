using Microsoft.EntityFrameworkCore;
using OldHome.DTO;
using OldHome.Entities;

namespace OldHome.Service.Endpoints
{
    public static class MediciationPrescriptionEndpoints
    {
        public static void MapMediciationPrescriptionEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("medication-prescriptions");
            EndpointsHelper.GetPage<MedicationPrescriptionDto, MedicationPrescription>(group,
                [q => q.Include(p => p.Resident),
                 q => q.Include(p => p.Doctor),
                 q => q.Include(p => p.Items).ThenInclude(i => i.Medicine)]);
            EndpointsHelper.Create<MedicationPrescriptionDto, MedicationPrescription, MedicationPrescriptionDto>(group);
            EndpointsHelper.Modify<MedicationPrescriptionDto, MedicationPrescription>(group);
            EndpointsHelper.Delete<MedicationPrescription>(group);
        }
    }
}
