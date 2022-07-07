using AutoMapper;
using Petfy.Data.Models;
using Petfy.Data.Repositories;
using Petfy.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly IPetRepository _petRepository;
        private readonly IMapper _mapper;

        public PetService(IPetRepository petRepository, IMapper mapper)
        {
            _petRepository = petRepository;
            _mapper = mapper;
        }

        public IEnumerable<PetDTO> GetAllPets()
        {
            var pets = _petRepository.GetAllPets();
            var petsToReturn = _mapper.Map<IEnumerable<PetDTO>>(pets);
            return petsToReturn;
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

        public PetDTO GetById(int Id)
        {
            var pet = _petRepository.GetById(Id);
            var petToReturn = _mapper.Map<PetDTO>(pet);
            return petToReturn;
        }

        public void AddPet(PetDTO petDTO)
        {
            try
            {
                Pet pet = new Pet()
                {
                    Name = petDTO.Name,
                    Breed = petDTO.Breed,
                    Description = petDTO.Description,
                    PetNumber = petDTO.PetNumber,
                    DateOfBirth = petDTO.DateOfBirth,
                    Type = petDTO.Type,
                    OwnerID = petDTO.OwnerID
                };
                _petRepository.AddPet(pet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Pet EditPet(int Id, PetDTO UpdatedPet)
        {
            var oldPet = _petRepository.GetById(Id);
            if (oldPet != null)
            {
                oldPet.Description = UpdatedPet.Description;
                oldPet.Name = UpdatedPet.Name;
                //oldPet.Breed = UpdatedPet.Breed;
                //oldPet.Type = UpdatedPet.Type;
                oldPet.DateOfBirth = UpdatedPet.DateOfBirth;
                oldPet.PetNumber = UpdatedPet.PetNumber;
                try
                {
                    return _petRepository.EditPet(oldPet);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return null;
        }

        public bool DeletePet(int Id)
        {
            if (Id <= 0)
            {
                return false;
            }

            var pet = _petRepository.GetById(Id);

            if (pet == null)
            {
                throw new ApplicationException("Pet not found");
            }

            if (pet.Owner == null)
            {
                throw new ApplicationException("Pet cannot be deleted because it has an owner.");
            }

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
