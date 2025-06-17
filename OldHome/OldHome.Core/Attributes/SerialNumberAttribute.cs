using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Core.Attributes
{
    public class SerialNumberAttribute : Attribute
    {
        /// <summary>
        /// 序列号类型
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 前缀（可选，如果不设置则使用 SerialNumber 表中的配置）
        /// </summary>
        public string? Prefix { get; set; }

        /// <summary>
        /// 后缀（可选，如果不设置则使用 SerialNumber 表中的配置）
        /// </summary>
        public string? Suffix { get; set; }

        /// <summary>
        /// 日期格式（默认：yyyyMMdd）
        /// </summary>
        public string DateFormat { get; set; } = "yyyyMMdd";

        /// <summary>
        /// 序号位数（默认：4位）
        /// </summary>
        public int NumberLength { get; set; } = 4;

        /// <summary>
        /// 是否按日重置序号
        /// </summary>
        public bool ResetDaily { get; set; } = true;

        public SerialNumberAttribute(string type)
        {
            Type = type;
        }
    }
}
