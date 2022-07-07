using System.ComponentModel.DataAnnotations;

namespace Petfy.Domain.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
