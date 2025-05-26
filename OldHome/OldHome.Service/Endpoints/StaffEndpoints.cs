using Microsoft.EntityFrameworkCore;
using OldHome.DTO;
using OldHome.Entities;

namespace OldHome.Service.Endpoints
{
    public static class StaffEndpoints
    {
        public static void MapStaffEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/staffs");

            EndpointsHelper.GetPage<StaffDto, Staff>(group, [q => q.Include(p => p.Org), q => q.Include(p => p.Department)]);

            EndpointsHelper.GetAllSamples<StaffSample, Staff>(group);

            EndpointsHelper.Create<StaffCreateDto, Staff, StaffDto>(group);

            EndpointsHelper.Modify<StaffModifyDto, Staff>(group);

            EndpointsHelper.Delete<Staff>(group);
        }
    }
}
