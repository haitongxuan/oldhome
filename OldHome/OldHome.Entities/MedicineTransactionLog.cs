using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class MedicineTransactionLog : BaseOrgByEntity
    {
        public int InventoryId { get; set; }
        public MedicineInventory MedicineInventory { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        public MedicineInventoryOperationType OperationType { get; set; } = MedicineInventoryOperationType.Inbound;
        public int QtyChanged { get; set; }
        public MedicineUnit Unit { get; set; } = MedicineUnit.Tablet;
        public MedicineInventoryType InventoryType { get; set; } = MedicineInventoryType.Personal;
        public int? ResidentId { get; set; }
        public Resident? Resident { get; set; }
        public string Notes { get; set; } = string.Empty;
    }
}
