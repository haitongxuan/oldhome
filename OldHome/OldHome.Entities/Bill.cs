using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class Bill : BaseOrgByEntity
    {
        public string BillNum { get; set; } = string.Empty;
        public DateOnly BillDate { get; set; } = DateOnly.FromDateTime(DateTime.UtcNow);
        public decimal Amount { get; set; }
        public string Description { get; set; } = string.Empty;
        public bool Paid { get; set; } = false;
        public int ResidentId { get; set; }
        public Resident Resident { get; set; } = new Resident();
    }
}
