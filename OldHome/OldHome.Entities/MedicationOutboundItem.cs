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
    /// 发药出库明细
    /// </summary>
    public class MedicationOutboundItem : BaseEntity
    {
        /// <summary>
        /// 发药出库单ID
        /// </summary>
        public int OutboundId { get; set; }
        public MedicationOutbound Outbound { get; set; } = new MedicationOutbound();

        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();

        /// <summary>
        /// 药品ID（冗余字段）
        /// </summary>
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = new Medicine();

        /// <summary>
        /// 计划用量
        /// </summary>
        public decimal PlannedQuantity { get; set; }

        /// <summary>
        /// 实际出库量
        /// </summary>
        public decimal ActualQuantity { get; set; }

        /// <summary>
        /// 发药状态
        /// </summary>
        public DispenseStatus DispenseStatus { get; set; } = DispenseStatus.Prepared;


        /// <summary>
        /// 住户确认时间
        /// </summary>
        public DateTime? ResidentConfirmedTime { get; set; }
    }
}
