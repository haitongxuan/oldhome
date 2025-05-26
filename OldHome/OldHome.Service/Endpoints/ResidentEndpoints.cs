using OldHome.DTO;
using OldHome.Entities;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using OldHome.DAL;
using System.Security.Claims;
using OldHome.DTO.Base;

namespace OldHome.Service.Endpoints
{
    public static class ResidentEndpoints
    {
        public static void MapResidentEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/residents");

            EndpointsHelper.GetAll<ResidentDto, Resident>(group, [q => q.Include(p => p.OrgArea), q => q.Include(p => p.Room), q => q.Include(p => p.Bed)]);

            EndpointsHelper.GetPage<ResidentDto, Resident>(group, [q => q.Include(p => p.OrgArea), q => q.Include(p => p.Room), q => q.Include(p => p.Bed)]);

            EndpointsHelper.GetAllSamples<ResidentSample, Resident>(group, [q => q.Include(p => p.Room)]);

            EndpointsHelper.Create<ResidentCreate, Resident, ResidentDto>(group);

            group.MapPost("/create", async (AppDataContext db, IMapper mapper, ResidentCreate dto, HttpContext httpContext, HttpRequest request) =>
            {
                try
                {
                    var userName = httpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? "";

                    dto.CreatedAt = DateTime.UtcNow;
                    dto.UpdateAt = DateTime.UtcNow;
                    dto.CreatedBy = userName;
                    dto.UpdateBy = userName;

                    dto.OrgId = Convert.ToInt32(request.Headers["OrgId"].ToString());

                    var entity = mapper.Map<Resident>(dto);
                    entity.Code = GetResidentCode(db, dto.OrgId);
                    var result = await db.Set<Resident>().AddAsync(entity);
                    await db.SaveChangesAsync();
                    return Results.Ok(mapper.Map<ResidentDto>(result.Entity));
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });

            EndpointsHelper.Modify<ResidentModify, Resident>(group);

            EndpointsHelper.Delete<Resident>(group);
        }

        public static string GetResidentCode(AppDataContext db, int orgId)
        {
            var set = db.Set<ResidentSeq>();
            var r = set.First(p => p.Date.Equals(DateOnly.FromDateTime(DateTime.Today)) && p.OrgId == orgId);
            string code = string.Empty;
            if (r is null)
            {
                var nr = new ResidentSeq() { Date = DateOnly.FromDateTime(DateTime.Today), Seq = 1, OrgId = orgId, CreatedAt = DateTime.Now, CreatedBy = "system" };
                set.Add(nr);
                code = DateTime.Today.ToShortDateString() + 1.ToString("D2");
            }
            else
            {
                r.Seq += 1;
                code = r.Date.ToShortDateString() + r.Seq.ToString("D2");
            }
            return code;
        }
    }
}
