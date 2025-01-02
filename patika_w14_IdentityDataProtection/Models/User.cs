using System.ComponentModel.DataAnnotations;

namespace patika_w14_IdentityDataProtection.Models
{
    public class User
    {
        public int id {  get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
