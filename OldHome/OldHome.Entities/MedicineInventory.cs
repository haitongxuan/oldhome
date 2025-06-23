using OldHome.Core;
using OldHome.Core.Attributes;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class MedicineInventory : BaseOrgByEntity, ISerialNumberEntity
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        [SerialNumber("MIBATCH", Prefix = "MIB")]
        public string BatchNumber { get; set; } = string.Empty;
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
        public int? ResidentId { get; set; }
        public Resident? Resident { get; set; }
        public string? ResidentName { get; set; }
        public string? ResidentCode { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public MedicineInventoryStatus Status { get; set; } = MedicineInventoryStatus.Normal;
    }
}
