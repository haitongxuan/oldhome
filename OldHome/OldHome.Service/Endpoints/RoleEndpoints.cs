using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.Entities;

namespace OldHome.Service.Endpoints
{
    public static class RoleEndpoints
    {
        public static void MapRoleEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/roles");
            EndpointsHelper.GetAllSamples<RoleSample, Role>(group);

            EndpointsHelper.GetAll<RoleDto, Role>(group);

            EndpointsHelper.Create<RoleCreate, Role, RoleDto>(group);

            EndpointsHelper.Modify<RoleModify, Role>(group);

            EndpointsHelper.Delete<Role>(group);
        }
    }
}
