using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OldHome.BLL;
using OldHome.DAL;
using OldHome.DTO;
using OldHome.DTO.Base;
using OldHome.Entities;
using OldHome.Entities.Base;
using System.Security.Claims;

namespace OldHome.Service.Endpoints
{
    public static class MedicationOutboundEndpoints
    {
        public static void MapMedicationOutboundEndpoints(this IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("medication-outbounds");

            // 分页查询
            EndpointsHelper.GetPage<MedicationOutboundDto, MedicationOutbound>(group,
                [
                    q => q.Include(p => p.Pharmacist),
                    q => q.Include(p => p.CheckedBy),
                    q => q.Include(p => p.Items)
                        .ThenInclude(i => i.Resident),
                    q => q.Include(p => p.Items)
                        .ThenInclude(i => i.Medicine)
                ]);

            // 获取所有记录
            EndpointsHelper.GetAll<MedicationOutboundDto, MedicationOutbound>(group,
                [
                    q => q.Include(p => p.Pharmacist),
                    q => q.Include(p => p.CheckedBy),
                    q => q.Include(p => p.Items)
                        .ThenInclude(i => i.Resident),
                    q => q.Include(p => p.Items)
                        .ThenInclude(i => i.Medicine),
                    q => q.Include(p => p.Items)
                ]);

            // 获取样例记录
            EndpointsHelper.GetAllSamples<MedicationOutboundSampleDto, MedicationOutbound>(group,
                [
                    q => q.Include(p => p.Pharmacist)
                ]);


            // 修改记录
            EndpointsHelper.ModifyItems<MedicationOutboundModifyDto, MedicationOutbound, MedicationOutboundItem>(group);

            // 删除记录
            EndpointsHelper.Delete<MedicationOutbound>(group);

            // 创建发药记录
            Create(group);
        }

        public static void Create(RouteGroupBuilder group, bool authorize = true)
        {
            var req = group.MapPost("/create",
                async (AppDataContext db, IMapper mapper, MedicationOutboundCreateDto dto,
                HttpContext httpContext, HttpRequest request, InventoryBLL inventoryBLL) =>
            {
                try
                {
                    var userName = httpContext.User.FindFirst(ClaimTypes.Name)?.Value ?? "";

                    dto.CreatedAt = DateTime.UtcNow;
                    dto.UpdateAt = DateTime.UtcNow;
                    dto.CreatedBy = userName;
                    dto.UpdateBy = userName;
                    dto.OrgId = Convert.ToInt32(request.Headers["OrgId"].ToString());
                    var entity = mapper.Map<MedicationOutbound>(dto);
                    var result = await inventoryBLL.CreateMedicationOutboundAsync(entity);
                    return Results.Ok(mapper.Map<MedicationOutboundDto>(result));
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex.Message);
                }
            });
            if (authorize)
            {
                req.RequireAuthorization();
            }
        }
    }
}