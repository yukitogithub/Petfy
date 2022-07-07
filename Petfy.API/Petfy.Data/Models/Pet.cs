﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Petfy.Data.Models
{
    public class Pet
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? PetNumber { get; set; }
        public string Description { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Type { get; set; }
        public Owner Owner { get; set; }
        
        //[ForeignKey("OwnerID")]
        public int OwnerID { get; set; }

        //public List<PetVaccine> PetVaccines { get; set; } = new List<PetVaccine>();
        public List<Vaccine> Vaccines { get; set; } = new List<Vaccine>();

        public List<Photo> Photos { get; set; }

        public int GetAge()
        {
            var age = DateTime.Today.Year - DateOfBirth.Year;

            if (DateOfBirth.Date > DateTime.Today.AddYears(-age)) age--;

            return age;
        }
    }
}