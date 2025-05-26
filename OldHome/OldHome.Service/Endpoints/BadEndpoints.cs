using Microsoft.EntityFrameworkCore;
using OldHome.DTO;
using OldHome.Entities;

namespace OldHome.Service.Endpoints
{
    public static class BadEndpoints
    {
        public static void MapBedEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("beds");

            EndpointsHelper.GetPage<BedDto, Bed>(group, [q => q.Include(p => p.Org), q => q.Include(p => p.Room), q => q.Include(p => p.OrgArea)]);

            EndpointsHelper.GetAll<BedDto, Bed>(group, [q => q.Include(p => p.Org), q => q.Include(p => p.Room), q => q.Include(p => p.OrgArea)]);

            EndpointsHelper.GetAllSamples<BedSample, Bed>(group, [q => q.Include(p => p.Room)]);

            EndpointsHelper.Create<BedCreate, Bed, BedDto>(group);

            EndpointsHelper.Modify<BedModify, Bed>(group);

            EndpointsHelper.Delete<Bed>(group);
        }
    }
}
