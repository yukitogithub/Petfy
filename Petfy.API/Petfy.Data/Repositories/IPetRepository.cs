﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Petfy.Data.Models;

namespace Petfy.Data.Repositories
{
    public interface IPetRepository
    {
        public List<Pet> GetAllPets(); //GetAll

        //public List<Pet> GetByBreed(string Breed);

        //public List<Pet> GetByOwnerId(int OwnerId);

        //public List<Vaccine> GetAllVaccines(int PetId);
        
        public Pet GetById(int Id); //GetById

        public void AddPet(Pet pet); //AddPet

        public Pet EditPet(Pet UpdatedPet); //EditPet

        public bool DeletePet(int Id); //DeletePet
    }
}
