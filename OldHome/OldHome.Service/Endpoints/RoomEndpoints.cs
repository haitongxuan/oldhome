using OldHome.DTO;
using OldHome.Entities;
using Microsoft.EntityFrameworkCore;

namespace OldHome.Service.Endpoints
{
    public static class RoomEndpoints
    {
        public static void MapRoomEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/rooms");

            EndpointsHelper.GetPage<RoomDto, Room>(group,
                [q => q.Include(p => p.Org), q => q.Include(p => p.OrgArea)]);

            EndpointsHelper.GetAllSamples<RoomSample, Room>(group, [q => q.Include(p => p.OrgArea)]);

            EndpointsHelper.Create<RoomCreate, Room, RoomDto>(group);

            EndpointsHelper.Modify<RoomModify, Room>(group);

            EndpointsHelper.Delete<Room>(group);
        }
    }
}
