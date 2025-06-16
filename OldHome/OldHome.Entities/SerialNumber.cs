using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class SerialNumber : BaseOrgByEntity
    {
        /// <summary>
        /// 序列号类型
        /// </summary>
        public string Type { get; set; } = string.Empty;
        /// <summary>
        /// 当前序列号值
        /// </summary>
        public int CurrentValue { get; set; } = 0;
        /// <summary>
        /// 前缀（可选）
        /// </summary>
        public string Prefix { get; set; } = string.Empty;
        /// <summary>
        /// 后缀（可选）
        /// </summary>
        public string Suffix { get; set; } = string.Empty;
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsActive { get; set; } = true;
    }
}
