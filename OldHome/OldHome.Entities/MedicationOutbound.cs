using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    /// <summary>
    /// 发药出库单 - 专门用于发药的出库单
    /// </summary>
    public class MedicationOutbound : BaseItemsOrgByEntity<MedicationOutboundItem>
    {
        /// <summary>
        /// 发药单号
        /// </summary>
        public string OutboundNumber { get; set; } = string.Empty;

        /// <summary>
        /// 发药日期
        /// </summary>
        public DateOnly OutboundDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// 发药时间段
        /// </summary>
        public MedicineTime MedicineTime { get; set; }

        /// <summary>
        /// 发药类型
        /// </summary>
        public MedicationOutboundType OutboundType { get; set; } = MedicationOutboundType.Regular;

        /// <summary>
        /// 发药护士ID
        /// </summary>
        public int PharmacistId { get; set; }
        public Staff Pharmacist { get; set; } = new Staff();

        /// <summary>
        /// 核对护士ID
        /// </summary>
        public int? CheckedById { get; set; }
        public Staff? CheckedBy { get; set; }

        /// <summary>
        /// 出库状态
        /// </summary>
        public MedicationOutboundStatus Status { get; set; } = MedicationOutboundStatus.Draft;

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime PreparedTime { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// 核对时间
        /// </summary>
        public DateTime? CheckedTime { get; set; }

        /// <summary>
        /// 发放时间
        /// </summary>
        public DateTime? DispensedTime { get; set; }

        /// <summary>
        /// 总药品数量
        /// </summary>
        public int TotalItemCount { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 发药明细
        /// </summary>
        public List<MedicationOutboundItem> Items { get; set; } = new List<MedicationOutboundItem>();
    }
}
