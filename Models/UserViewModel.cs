using System.ComponentModel.DataAnnotations;

namespace GoRestUserManager.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad boş olamaz")]
        public string Name { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Status { get; set; }
    }
}