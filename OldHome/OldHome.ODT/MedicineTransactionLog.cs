using OldHome.Core;
using OldHome.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO
{
    public class MedicineTransactionLogDto : BaseOrgByDto
    {
        public int InventoryId { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public MedicineInventoryOperationType OperationType { get; set; } = MedicineInventoryOperationType.Inbound;
        public int QtyChanged { get; set; }
        public MedicineUnit Unit { get; set; } = MedicineUnit.Tablet;
        public MedicineInventoryType InventoryType { get; set; } = MedicineInventoryType.Personal;
        public int? ResidentId { get; set; }
        public string? ResidentName { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
    }

    public class MedicineTransactionLogCreate : BaseOrgByDto
    {
        public int InventoryId { get; set; }
        public int MedicineId { get; set; }
        public MedicineInventoryOperationType OperationType { get; set; } = MedicineInventoryOperationType.Inbound;
        public int QtyChanged { get; set; }
        public MedicineUnit Unit { get; set; } = MedicineUnit.Tablet;
        public MedicineInventoryType InventoryType { get; set; } = MedicineInventoryType.Personal;
        public int? ResidentId { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

    public class MedicineTransactionLogModify : BaseOrgByDto
    {
        public int InventoryId { get; set; }
        public int MedicineId { get; set; }
        public MedicineInventoryOperationType OperationType { get; set; } = MedicineInventoryOperationType.Inbound;
        public int QtyChanged { get; set; }
        public MedicineUnit Unit { get; set; } = MedicineUnit.Tablet;
        public MedicineInventoryType InventoryType { get; set; } = MedicineInventoryType.Personal;
        public int? ResidentId { get; set; }
        public string Notes { get; set; } = string.Empty;
    }

}
