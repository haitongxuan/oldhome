using System.ComponentModel.DataAnnotations;

namespace OldHome.Wasm.Models
{
    public class LoginParamsType
    {
        [Required] public string UserName { get; set; }

        [Required] public string Password { get; set; }

        [Required] public int OrgId { get; set; }

        public bool AutoLogin { get; set; }
    }
}
