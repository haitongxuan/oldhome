using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.Entities;

namespace OldHome.Service.Endpoints
{
    public static class OrgEndpoints
    {
        public static void MapOrgEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/orgs");

            EndpointsHelper.GetAll<OrgDto, Org>(group, [q => q.Include(p => p.OrgAreas)]);

            EndpointsHelper.GetAllSamples<OrgSample, Org>(group, authorize: false);

            EndpointsHelper.Create<OrgCreate, Org, OrgDto>(group);

            EndpointsHelper.Modify<OrgModify, Org>(group);

            EndpointsHelper.Delete<Org>(group);

            group.MapGet("/{id}/orgareas", async (int id, AppDataContext db, IMapper mapper) =>
            {
                var orgAreas = await db.OrgAreas
                    .Where(x => x.OrgId == id)
                    .Include(p => p.Org)
                    .ToListAsync();
                return Results.Ok(mapper.Map<List<OrgAreaDto>>(orgAreas));
            });
        }

    }
}