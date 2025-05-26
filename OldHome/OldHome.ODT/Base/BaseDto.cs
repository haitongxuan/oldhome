using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO.Base
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? UpdateAt { get; set; } = DateTime.UtcNow;
        public string UpdateBy { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
