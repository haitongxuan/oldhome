using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class MedicineAlterLog : BaseOrgByEntity
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
        /// <summary>
        /// 变更类型
        /// </summary>
        public MedicineAlterType AlterType { get; set; }
        public int? ResidentId { get; set; }
        public Resident? Resident { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Notified { get; set; } = false;
        public string NotifiedTo { get; set; } = string.Empty;
        /// <summary>
        /// 通知方式
        /// </summary>
        public NotificationType NotifiedBy { get; set; } = NotificationType.None;
    }
}
