using Microsoft.EntityFrameworkCore;
using OldHome.DTO;
using OldHome.Entities;

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
                        .ThenInclude(i => i.Medicine),
                    q => q.Include(p => p.Items)
                        .ThenInclude(i => i.Schedule),
                    q => q.Include(p => p.Items)
                        .ThenInclude(i => i.Inventory)
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
                        .ThenInclude(i => i.Schedule),
                    q => q.Include(p => p.Items)
                        .ThenInclude(i => i.Inventory)
                ]);

            // 获取样例记录
            EndpointsHelper.GetAllSamples<MedicationOutboundSampleDto, MedicationOutbound>(group,
                [
                    q => q.Include(p => p.Pharmacist)
                ]);

            // 创建记录
            EndpointsHelper.Create<MedicationOutboundCreateDto, MedicationOutbound, MedicationOutboundDto>(group);

            // 修改记录
            EndpointsHelper.ModifyItems<MedicationOutboundModifyDto, MedicationOutbound, MedicationOutboundItem>(group);

            // 删除记录
            EndpointsHelper.Delete<MedicationOutbound>(group);
        }
    }
}