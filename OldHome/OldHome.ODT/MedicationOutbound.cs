using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    /// <summary>
    /// 发药出库单 DTO
    /// </summary>
    public class MedicationOutboundDto : BaseOrgByDto
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
        public string PharmacistName { get; set; } = string.Empty;

        /// <summary>
        /// 核对护士ID
        /// </summary>
        public int? CheckedById { get; set; }
        public string? CheckedByName { get; set; }

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
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 发药明细
        /// </summary>
        public List<MedicationOutboundItemDto> Items { get; set; } = new List<MedicationOutboundItemDto>();
    }

    /// <summary>
    /// 发药出库单创建 DTO
    /// </summary>
    public class MedicationOutboundCreateDto : BaseOrgByDto
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

        /// <summary>
        /// 核对护士ID
        /// </summary>
        public int? CheckedById { get; set; }

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
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 发药明细
        /// </summary>
        public List<MedicationOutboundItemDto> Items { get; set; } = new List<MedicationOutboundItemDto>();
    }

    /// <summary>
    /// 发药出库单修改 DTO
    /// </summary>
    public class MedicationOutboundModifyDto : BaseOrgByDto
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

        /// <summary>
        /// 核对护士ID
        /// </summary>
        public int? CheckedById { get; set; }

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
        /// 备注
        /// </summary>
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// 发药明细
        /// </summary>
        public List<MedicationOutboundItemDto> Items { get; set; } = new List<MedicationOutboundItemDto>();
    }

    /// <summary>
    /// 发药出库单样例 DTO
    /// </summary>
    public class MedicationOutboundSampleDto : BaseOrgByDto
    {
        /// <summary>
        /// 发药单号
        /// </summary>
        public string OutboundNumber { get; set; } = string.Empty;

        /// <summary>
        /// 发药日期
        /// </summary>
        public DateOnly OutboundDate { get; set; }

        /// <summary>
        /// 发药时间段
        /// </summary>
        public MedicineTime MedicineTime { get; set; }

        /// <summary>
        /// 出库状态
        /// </summary>
        public MedicationOutboundStatus Status { get; set; }

        /// <summary>
        /// 发药护士姓名
        /// </summary>
        public string PharmacistName { get; set; } = string.Empty;
    }

    /// <summary>
    /// 发药出库明细 DTO
    /// </summary>
    public class MedicationOutboundItemDto : BaseDto
    {
        /// <summary>
        /// 发药出库单ID
        /// </summary>
        public int OutboundId { get; set; }

        /// <summary>
        /// 住户ID
        /// </summary>
        public int ResidentId { get; set; }
        public string ResidentName { get; set; } = string.Empty;

        /// <summary>
        /// 发药计划ID
        /// </summary>
        public int ScheduleId { get; set; }

        /// <summary>
        /// 库存记录ID
        /// </summary>
        public int InventoryId { get; set; }

        /// <summary>
        /// 药品ID（冗余字段）
        /// </summary>
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;


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