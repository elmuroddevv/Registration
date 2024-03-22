using System.ComponentModel.DataAnnotations;

namespace Registration.Models
{
    public class RegisterModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string FullName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Login { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Password { get; set; }
    }
}
