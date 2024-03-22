using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
