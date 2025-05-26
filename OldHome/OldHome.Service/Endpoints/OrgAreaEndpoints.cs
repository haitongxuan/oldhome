using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.Entities;

namespace OldHome.Service.Endpoints
{
    public static class OrgAreaEndpoints
    {
        public static void MapOrgAreaEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/orgareas");

            EndpointsHelper.GetAll<OrgAreaDto, OrgArea>(group, [q => q.Include(p => p.Org)]);

            EndpointsHelper.GetAllSamples<OrgAreaSample, OrgArea>(group, [q => q.Include(p => p.Org)]);

            EndpointsHelper.Create<OrgAreaCreate, OrgArea, OrgAreaDto>(group);

            EndpointsHelper.Modify<OrgAreaModify, OrgArea>(group);

            EndpointsHelper.Delete<OrgArea>(group);

        }
    }
}
