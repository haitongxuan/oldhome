using OldHome.DTO;
using Microsoft.EntityFrameworkCore;
using OldHome.Entities;

namespace OldHome.Service.Endpoints
{
    public static class DepartmentEndpoints
    {
        public static void MapDepartmentEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/departments");

            EndpointsHelper.GetAll<DepartmentDto, Department>(group,
                [q => q.Include(p => p.Org)]);

            EndpointsHelper.GetAllSamples<DepartmentSample, Department>(group);

            EndpointsHelper.Create<DepartmentCreate, Department, DepartmentDto>(group);

            EndpointsHelper.Modify<DepartmentModify, Department>(group);

            EndpointsHelper.Delete<Department>(group);
        }
    }
}
