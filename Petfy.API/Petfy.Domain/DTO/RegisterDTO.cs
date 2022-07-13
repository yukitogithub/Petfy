using System.ComponentModel.DataAnnotations;

namespace Petfy.Domain.DTO
{
    public class RegisterDTO
    {
        [Required]
        public string Username { get; set; }
        
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required, MinLength(8)]
        public string Password { get; set; }
    }
}
