using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class CareRecord
    {
        public int Id { get; set; }
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();
        public int StaffId { get; set; }
        public Staff Staff { get; set; } = new Staff();
        public string Notes { get; set; } = string.Empty;
    }
}
