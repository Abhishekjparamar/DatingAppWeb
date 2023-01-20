using System.ComponentModel.DataAnnotations;

namespace DatingAppWeb.DTOs
{
    public class AppUserDTO
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [StringLength(8,MinimumLength =4)]
        public string Password { get; set; }
    }
}
