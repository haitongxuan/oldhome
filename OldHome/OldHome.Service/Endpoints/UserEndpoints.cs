using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.DTO.Base;
using OldHome.Entities;
using OldHome.Service.Helpers;

namespace OldHome.Service.Endpoints
{
    public static class UserEndpoints
    {
        public static void MapUserEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/users");

            EndpointsHelper.GetAll<UserDto, User>(group,
                [q => q.Include(p => p.Org), q => q.Include(p => p.Role)]);

            EndpointsHelper.GetPage<UserDto, User>(group,
                [q => q.Include(p => p.Org), q => q.Include(p => p.Role)]);

            EndpointsHelper.Create<UserCreate, User, UserDto>(group);

            EndpointsHelper.Modify<UserModify, User>(group);

            EndpointsHelper.Delete<User>(group);
        }

    }
}
