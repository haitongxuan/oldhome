using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.Entities;

namespace OldHome.Service.Endpoints
{
    public static class EmergencyContactEndpoints
    {
        public static void MapEmergencyContactEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/emergencycontacts");

            EndpointsHelper.GetPage<EmergencyContactDto, EmergencyContact>(group,
                [q => q.Include(p => p.Org)]);

            EndpointsHelper.Create<EmergencyContactCreate, EmergencyContact, EmergencyContactDto>(group);

            EndpointsHelper.Modify<EmergencyContactModify, EmergencyContact>(group);

            EndpointsHelper.Delete<EmergencyContact>(group);

            EndpointsHelper.GetTop10Samples<EmergencyContactSample, EmergencyContact>(group);
        }
    }
}
