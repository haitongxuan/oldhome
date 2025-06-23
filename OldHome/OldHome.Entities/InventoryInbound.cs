using OldHome.Core;
using OldHome.Core.Attributes;
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
    /// 入库单 - 简化版
    /// </summary>
    public class InventoryInbound : BaseOrgByEntity
    {
        /// <summary>
        /// 入库单号
        /// </summary>
        [SerialNumber("INBOUND", Prefix = "INB")]
        public string InboundNumber { get; set; } = string.Empty;

        /// <summary>
        /// 入库类型
        /// </summary>
        public InboundType InboundType { get; set; }

        /// <summary>
        /// 药品来源类型
        /// </summary>
        public MedicineSourceType SourceType { get; set; }

        /// <summary>
        /// 入库日期
        /// </summary>
        public DateOnly InboundDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// 来源详情
        /// </summary>
        public string SourceInfo { get; set; } = string.Empty;

        /// <summary>
        /// 关联住户ID（家属提供时）
        /// </summary>
        public int? ResidentId { get; set; }
        public Resident? Resident { get; set; }

        /// <summary>
        /// 购买凭证
        /// </summary>
        public string? PurchaseReference { get; set; }

        /// <summary>
        /// 总价值（可选）
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalValue { get; set; }

        /// <summary>
        /// 入库状态
        /// </summary>
        public InboundStatus Status { get; set; } = InboundStatus.Draft;

        /// <summary>
        /// 验收人员ID
        /// </summary>
        public int? CheckedById { get; set; }
        public User? CheckedBy { get; set; }

        /// <summary>
        /// 验收日期
        /// </summary>
        public DateOnly? CheckedDate { get; set; }

        /// <summary>
        /// 入库人员ID
        /// </summary>
        public int? InboundById { get; set; }
        public User? InboundBy { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 入库明细
        /// </summary>
        public List<InventoryInboundItem> Items { get; set; } = new List<InventoryInboundItem>();
    }
}
