using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class Medicine : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Specification { get; set; } = string.Empty;
        public string? Manufacturer { get; set; } = string.Empty;
        public string? StorageMethod { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public MedicinePackageUnit PackageUnit { get; set; } = MedicinePackageUnit.Box;
        public MedicineUnit MinUnit { get; set; } = MedicineUnit.Tablet;
        public int QtyPerPackage { get; set; }
        public string Barcode { get; set; } = string.Empty;
        /// <summary>
        /// 国药准字编号
        /// </summary>
        public string? ApprovalNumber { get; set; } = string.Empty;
    }
}
