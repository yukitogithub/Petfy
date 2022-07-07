using System.ComponentModel.DataAnnotations;

namespace Petfy.Domain.DTO
{
    public class LoginDTO
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
