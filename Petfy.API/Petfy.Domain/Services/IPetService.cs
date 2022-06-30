using Petfy.Data.Models;
using Petfy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Services
{
    public interface IPetService
    {
        public List<Pet> GetAllPets(); //GetAll

        public List<Pet> GetByBreed(string Breed);

        public List<Pet> GetByOwnerId(int OwnerId);

        public List<Vaccine> GetAllVaccines(int PetId);

        public Pet GetById(int Id); //GetById

        public void AddPet(PetDTO pet); //AddPet

        public Pet EditPet(int Id, PetDTO UpdatedPet); //EditPet

        public bool DeletePet(int Id); //DeletePet
    }
}
