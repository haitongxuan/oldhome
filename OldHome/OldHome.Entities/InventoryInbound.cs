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
    /// 入库单 - 简化版
    /// </summary>
    public class InventoryInbound : BaseOrgByEntity
    {
        /// <summary>
        /// 入库单号
        /// </summary>
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
        public string SourceDetails { get; set; } = string.Empty;

        /// <summary>
        /// 提供人信息
        /// </summary>
        public string? ProviderInfo { get; set; }

        /// <summary>
        /// 提供人与住户关系
        /// </summary>
        public ContactRelationship? ProviderRelationship { get; set; }

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
