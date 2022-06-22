using Petfy.Data.Models;
using Petfy.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly PetRepository _petRepository;

        public PetService(PetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public List<Pet> GetAllPets()
        {
            return _petRepository.GetAllPets();
        }

        public List<Pet> GetByBreed(string Breed)
        {
            return _petRepository.GetAllPets().Where(p => p.Breed == Breed).ToList();
        }

        public List<Pet> GetByOwnerId(int OwnerId)
        {
            return _petRepository.GetAllPets().Where(p => p.OwnerID == OwnerId).ToList();
        }

        public List<Vaccine> GetAllVaccines(int PetId)
        {
            try
            {
                return _petRepository.GetAllPets().Where(p => p.ID == PetId).FirstOrDefault()?.Vaccines?.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pet GetById(int Id)
        {
            return _petRepository.GetById(Id);
        }

        public void AddPet(Pet pet)
        {
            try
            {
                _petRepository.AddPet(pet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pet EditPet(int Id, Pet UpdatedPet)
        {
            try
            {
                return _petRepository.EditPet(Id, UpdatedPet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeletePet(int Id)
        {
            try
            {
                return _petRepository.DeletePet(Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
