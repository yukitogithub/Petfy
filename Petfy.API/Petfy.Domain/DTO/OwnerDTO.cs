using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.DTO
{
    public class OwnerDTO
    {
        public int ID { get; set; }

        public string UserName { get; set; }
        
        public string Email { get; set; }
        
        public string Name { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Token { get; set; }

        public List<PetDTO> Pets { get; set; }
    }
}
