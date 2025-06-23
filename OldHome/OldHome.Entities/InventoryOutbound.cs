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
    /// 出库单
    /// </summary>
    public class InventoryOutbound : BaseOrgByEntity
    {
        /// <summary>
        /// 出库单号
        /// </summary>
        [SerialNumber("OUTBOUND", Prefix = "OUT")]
        public string OutboundNumber { get; set; } = string.Empty;

        /// <summary>
        /// 出库类型
        /// </summary>
        public OutboundType OutboundType { get; set; }

        /// <summary>
        /// 出库日期
        /// </summary>
        public DateOnly OutboundDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);

        /// <summary>
        /// 申请人ID（如果是领用）
        /// </summary>
        public int? RequesterId { get; set; }
        public User? Requester { get; set; }


        /// <summary>
        /// 关联处方ID（如果是发药）
        /// </summary>
        public int? PrescriptionId { get; set; }

        /// <summary>
        /// 总金额
        /// </summary>
        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// 出库状态
        /// </summary>
        public OutboundStatus Status { get; set; } = OutboundStatus.Draft;

        /// <summary>
        /// 审批人ID
        /// </summary>
        public int? ApprovedById { get; set; }
        public User? ApprovedBy { get; set; }

        /// <summary>
        /// 审批日期
        /// </summary>
        public DateOnly? ApprovedDate { get; set; }

        /// <summary>
        /// 出库人员ID
        /// </summary>
        public int? OutboundById { get; set; }
        public User? OutboundBy { get; set; }

        /// <summary>
        /// 领取人签名
        /// </summary>
        public string? ReceiverSignature { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 出库明细
        /// </summary>
        public List<InventoryOutboundItem> Items { get; set; } = new List<InventoryOutboundItem>();
    }
}
