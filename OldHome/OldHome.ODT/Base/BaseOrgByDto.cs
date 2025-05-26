using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO.Base
{
    public class BaseOrgByDto : BaseDto
    {
        public int OrgId { get; set; }
        public OrgDto Org { get; set; }
    }

}
