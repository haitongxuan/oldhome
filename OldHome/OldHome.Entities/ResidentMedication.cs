using OldHome.Core;
using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class ResidentMedication : BaseOrgByEntity
    {
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();
        public int RoomId { get; set; }
        public Room Room { get; set; } = new Room();
        public List<ResidentMedicationItem> Items { get; set; } = new List<ResidentMedicationItem>();
        public string Notes { get; set; } = string.Empty;
    }
    
}
