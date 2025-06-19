using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.Entities.Base
{
    public class BaseItemsOrgByEntity<T> : BaseOrgByEntity where T : BaseEntity
    {
        public BaseItemsOrgByEntity()
        {
            Items = new List<T>();
        }
        public List<T> Items { get; set; }
    }
}
