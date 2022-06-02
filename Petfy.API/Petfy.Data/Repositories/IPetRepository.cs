using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petfy.Data.Models;

namespace Petfy.Data.Repositories
{
    public interface IPetRepository
    {
        public List<Pet> GetAllPets();
        void AddPet(Pet pet);
    }
}
