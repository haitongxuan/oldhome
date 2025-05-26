using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class MedicineInventoryDto : BaseOrgByDto
    {
        public int? ResidentId { get; set; }
        public ResidentSample? Resident { get; set; }
        public string? ResidentName { get; set; } = string.Empty;
        public string? ResidentCode { get; set; } = string.Empty;
        public int MedicineId { get; set; }
        public MedicineSample Medicine { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public string BatchNumber { get; set; } = string.Empty;
        /// <summary>
        /// 效期
        /// </summary>
        public DateOnly ExpirationDate { get; set; }
        /// <summary>
        /// 入库最初包装数量
        /// </summary>
        public int PackageCount { get; set; }
        /// <summary>
        /// 剩余最小单位数量
        /// </summary>
        public int QtyRemaining { get; set; }
        /// <summary>
        /// 最初入库最小单位数量
        /// </summary>
        public int QtyTotal { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public MedicineInventoryStatus Status { get; set; } = MedicineInventoryStatus.Normal;
    }

    public class MedicineInventoryCreate : BaseOrgByDto
    {
        public int? ResidentId { get; set; }
        public string? ResidentName { get; set; }
        public string? ResidentCode { get; set; }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public string MedicineBarcode { get; set; } = string.Empty;
        /// <summary>
        /// 效期
        /// </summary>
        public DateOnly ExpirationDate { get; set; }
        public string BatchNumber { get; set; } = string.Empty;
        /// <summary>
        /// 入库最初包装数量
        /// </summary>
        public int PackageCount { get; set; }
        /// <summary>
        /// 剩余最小单位数量
        /// </summary>
        public int QtyRemaining { get; set; }
        /// <summary>
        /// 最初入库数量
        /// </summary>
        public int QtyTotal { get; set; }
        public MedicineInventoryStatus Status { get; set; }
    }

    public class MedicineInventoryModify : BaseOrgByDto
    {
        public int? ResidentId { get; set; }
        public string? ResidentName { get; set; }
        public string? ResidentCode { get; set; }

        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public string MedicineBarcode { get; set; } = string.Empty;
        /// <summary>
        /// 效期
        /// </summary>
        public DateOnly ExpirationDate { get; set; }
        /// <summary>
        /// 入库最初包装数量
        /// </summary>
        public int PackageCount { get; set; }
        /// <summary>
        /// 剩余最小单位数量
        /// </summary>
        public int QtyRemaining { get; set; }
        /// <summary>
        /// 最初入库数量
        /// </summary>
        public int QtyTotal { get; set; }
        public MedicineInventoryStatus Status { get; set; }
    }
}
