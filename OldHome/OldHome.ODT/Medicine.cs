using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class MedicineDto : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// 规格
        /// </summary>
        public string Specification { get; set; } = string.Empty;
        /// <summary>
        /// 生产厂家
        /// </summary>
        public string Manufacturer { get; set; } = string.Empty;
        /// <summary>
        /// 存储方式
        /// </summary>
        public string StorageMethod { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public MedicinePackageUnit PackageUnit { get; set; } = MedicinePackageUnit.Box;
        public MedicineUnit MinUnit { get; set; } = MedicineUnit.Tablet;
        public int QtyPerPackage { get; set; }
        public string Barcode { get; set; } = string.Empty;
        /// <summary>
        /// 国药准字编号
        /// </summary>
        public string? ApprovalNumber { get; set; } = string.Empty;
    }

    public class MedicineCreate : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string StorageMethod { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public MedicinePackageUnit PackageUnit { get; set; } = MedicinePackageUnit.Box;
        public MedicineUnit MinUnit { get; set; } = MedicineUnit.Tablet;
        public int QtyPerPackage { get; set; }
        public string Barcode { get; set; } = string.Empty;
        /// <summary>
        /// 国药准字编号
        /// </summary>
        public string? ApprovalNumber { get; set; } = string.Empty;
    }

    public class MedicineModify : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
        public string StorageMethod { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public MedicinePackageUnit PackageUnit { get; set; } = MedicinePackageUnit.Box;
        public MedicineUnit MinUnit { get; set; } = MedicineUnit.Tablet;
        public int QtyPerPackage { get; set; }
        public string Barcode { get; set; } = string.Empty;
        /// <summary>
        /// 国药准字编号
        /// </summary>
        public string? ApprovalNumber { get; set; } = string.Empty;
    }

    public class MedicineSample : BaseDto
    {
        public string Name { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Barcode { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
        public string Manufacturer { get; set; } = string.Empty;
    }
}
