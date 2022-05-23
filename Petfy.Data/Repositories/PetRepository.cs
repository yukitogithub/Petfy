using Petfy.Data;
using Petfy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Data.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly PetfyDbContext context;

        public PetRepository(PetfyDbContext context)
        {
            this.context=context;
        }

        public List<Pet> GetAllPets()
        {
            return context.Pets.ToList();
        }

        public void AddPet(Pet pet)
        {
            context.Add(pet);
            context.SaveChanges();
        }
    }
}
