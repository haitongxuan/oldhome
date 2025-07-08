using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldHome.DTO.Base
{
    public class BaseDto
    {
        public int Id { get; set; }
        [Display(Name = "创建时间")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Display(Name = "创建人")]
        public string CreatedBy { get; set; } = string.Empty;
        [Display(Name = "更新时间")]
        public DateTime? UpdateAt { get; set; } = DateTime.UtcNow;
        [Display(Name = "更新人")]
        public string UpdateBy { get; set; } = string.Empty;
        [Display(Name = "是否已删除")]
        public bool IsDeleted { get; set; } = false;
    }
}
