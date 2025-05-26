using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities.Base
{
    public abstract class BaseOrgByEntity : BaseEntity
    {
        public int OrgId { get; set; }
        public Org Org { get; set; }
    }
}
