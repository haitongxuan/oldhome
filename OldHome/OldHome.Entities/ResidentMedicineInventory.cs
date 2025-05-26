using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class ResidentMedicineInventory : BaseOrgByEntity
    {
        public int ResidentId { get; set; }
        public Resident Resident { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        /// <summary>
        /// 当前剩余最小单位数（如8片）
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 库存预警阈值
        /// </summary>
        public int WarningThreshold { get; set; }
    }
}
