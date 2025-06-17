using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OldHome.Core.Attributes;
using OldHome.DAL;
using OldHome.Entities.Base;
using System.Reflection;

namespace OldHome.Service.Interceptors
{
    public class SerialNumberInterceptor : SaveChangesInterceptor
    {
        // 不再注入服务，而是在需要时创建
        public override InterceptionResult<int> SavingChanges(
            DbContextEventData eventData,
            InterceptionResult<int> result)
        {
            if (eventData.Context is AppDataContext context)
            {
                GenerateSerialNumbers(context);
            }
            return base.SavingChanges(eventData, result);
        }

        public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is AppDataContext context)
            {
                GenerateSerialNumbers(context);
            }
            return await base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private void GenerateSerialNumbers(AppDataContext context)
        {
            var entries = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is ISerialNumberEntity)
                .ToList();

            if (!entries.Any()) return;

            // 直接在这里实现序列号生成逻辑，避免循环依赖
            foreach (var entry in entries)
            {
                var entity = entry.Entity;
                var type = entity.GetType();
                var properties = type.GetProperties()
                    .Where(p => p.GetCustomAttribute<SerialNumberAttribute>() != null);

                foreach (var property in properties)
                {
                    var attribute = property.GetCustomAttribute<SerialNumberAttribute>();
                    if (attribute != null && property.PropertyType == typeof(string))
                    {
                        var currentValue = property.GetValue(entity) as string;
                        if (string.IsNullOrEmpty(currentValue))
                        {
                            var serialEntity = (ISerialNumberEntity)entity;
                            var serialNumber = GenerateNextSerialNumber(context, attribute.Type, serialEntity.OrgId, attribute);
                            property.SetValue(entity, serialNumber);
                        }
                    }
                }
            }
        }

        private string GenerateNextSerialNumber(AppDataContext context, string type, int orgId, SerialNumberAttribute attribute)
        {
            var today = DateTime.Today;
            var dateFormat = attribute?.DateFormat ?? "yyyyMMdd";
            var dateStr = today.ToString(dateFormat);
            var numberLength = attribute?.NumberLength ?? 4;

            // 查找对应的序列号记录
            var serial = context.SerialNumbers.Local
                .FirstOrDefault(s => s.Type == type && s.OrgId == orgId && s.IsActive);

            if (serial == null)
            {
                serial = context.SerialNumbers
                    .FirstOrDefault(s => s.Type == type && s.OrgId == orgId && s.IsActive);
            }

            if (serial == null)
            {
                serial = new Entities.SerialNumber
                {
                    Type = type,
                    OrgId = orgId,
                    CurrentValue = 1,
                    Prefix = attribute?.Prefix ?? "",
                    Suffix = attribute?.Suffix ?? "",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                context.SerialNumbers.Add(serial);
            }
            else
            {
                // 判断是否需要重置
                if (attribute?.ResetDaily == true && serial.UpdatedAt.Date != today)
                {
                    serial.CurrentValue = 1;
                }
                else
                {
                    serial.CurrentValue += 1;
                }
                serial.UpdatedAt = DateTime.Now;
            }

            // 使用属性中的前缀和后缀（如果提供），否则使用数据库中的配置
            var prefix = attribute?.Prefix ?? serial.Prefix;
            var suffix = attribute?.Suffix ?? serial.Suffix;

            // 生成序列号字符串
            var numberFormat = new string('0', numberLength);
            var serialNumber = $"{prefix}{dateStr}{serial.CurrentValue.ToString(numberFormat)}{suffix}";

            return serialNumber;
        }
    }
}
