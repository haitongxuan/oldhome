using OldHome.DAL;
using OldHome.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.BLL
{
    public class SerialNumberService
    {
        private readonly AppDataContext _context;
        public SerialNumberService(AppDataContext context)
        {
            _context = context;
        }
        /// <summary>
        /// 获取指定类型的下一个序列号
        /// </summary>
        /// <param name="type">序列号类型</param>
        /// <param name="orgId">组织Id</param>
        /// <returns>生成的序列号字符串</returns>
        public string GetNextSerialNumber(string type, int orgId)
        {
            var today = DateTime.Today;
            var dateStr = today.ToString("yyyyMMdd");

            // 查找对应的序列号记录
            var serial = _context.SerialNumbers
                .FirstOrDefault(s => s.Type == type && s.OrgId == orgId && s.IsActive);

            if (serial == null)
            {
                serial = new SerialNumber
                {
                    Type = type,
                    OrgId = orgId,
                    CurrentValue = 1,
                    Prefix = "",
                    Suffix = "",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                _context.SerialNumbers.Add(serial);
            }
            else
            {
                // 判断是否需要重置
                if (serial.UpdatedAt.Date != today)
                {
                    serial.CurrentValue = 1;
                }
                else
                {
                    serial.CurrentValue += 1;
                }
                serial.UpdatedAt = DateTime.Now;
            }

            _context.SaveChanges();

            // 生成序列号字符串
            var serialNumber = $"{serial.Prefix}{dateStr}{serial.CurrentValue:D4}{serial.Suffix}";
            return serialNumber;
        }
    }
}

