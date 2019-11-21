using System.ComponentModel.DataAnnotations;

namespace Auth.Models
{
    public class Login
    {
        [Required]
        public string EmailOrMobile { get; set; }

        [Required]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
