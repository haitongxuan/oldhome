using OldHome.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities
{
    public class ResidentSeq : BaseOrgByEntity
    {
        public DateOnly Date { get; set; }
        public int Seq { get; set; }
    }
}
