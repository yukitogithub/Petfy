using Microsoft.EntityFrameworkCore;
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
        private readonly PetfyDbContext _context;

        public PetRepository(PetfyDbContext context)
        {
            _context = context;
        }

        public List<Pet> GetAllPets()
        {
            return _context.Pets.Include(p => p.Vaccines).ToList();
        }

        //public List<Pet> GetByBreed(string Breed)
        //{
        //    return _context.Pets.Where(p => p.Breed == Breed).ToList();
        //}

        //public List<Pet> GetByOwnerId(int OwnerId)
        //{
        //    return _context.Pets.Where(p => p.OwnerID == OwnerId).ToList();
        //}

        //public List<Vaccine> GetAllVaccines(int PetId)
        //{
        //    try
        //    {
        //        return _context.Pets.Include(p => p.Vaccines).Where(p => p.ID == PetId).FirstOrDefault()?.Vaccines?.ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public Pet GetById(int Id)
        {
            return _context.Pets.Find(Id);
        }

        public void AddPet(Pet pet)
        {
            if(pet != null)
            {
                try
                {
                    _context.Pets.Add(pet);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Pet EditPet(Pet UpdatedPet)
        {
            //var oldPet = _context.Pets.Find(Id);
            //if(oldPet != null && oldPet.ID == UpdatedPet.ID)
            //{
                //oldPet.Description = UpdatedPet.Description;
                //oldPet.Name = UpdatedPet.Name;
                //oldPet.Breed = UpdatedPet.Breed;
                //oldPet.Type = UpdatedPet.Type;
                //oldPet.DateOfBirth = UpdatedPet.DateOfBirth;
                //oldPet.PetNumber = UpdatedPet.PetNumber;
                //oldPet.Vaccines = UpdatedPet.Vaccines;

                //_context.Update(oldPet);
            try
            {
                _context.Update(UpdatedPet);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return UpdatedPet;
            //}

            //return UpdatedPet;
        }

        public bool DeletePet(int Id)
        {
            var pet = _context.Pets.Find(Id);
            if (pet != null)
            {
                try
                {
                    _context.Pets.Remove(pet);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }

            return false;
        }
    }
}
