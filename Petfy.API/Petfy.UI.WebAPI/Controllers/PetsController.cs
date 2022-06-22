using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Petfy.Data;
using Petfy.Data.Models;
using Petfy.Domain.Services;

namespace Petfy.UI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PetsController : ControllerBase
    {
        private readonly PetService petservice;

        public PetsController(PetService petService)
        {
            petservice = petService;
        }

        // GET: api/Pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            var pets = petservice.GetAllPets();
            if (pets == null)
            {
                return NotFound();
            }
            return pets;
        }

        // GET: api/Pets/bullterrier
        [HttpGet("{breed}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets(string breed)
        {
            var pets = petservice.GetByBreed(breed);
            if (pets == null)
            {
                return NotFound();
            }
            return pets;
        }

        // GET: api/Pets/Breed/BullTerrier/OwnerId/5
        [HttpGet("/breed/{breed}/ownerid/{ownerId:int}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets(string breed, int ownerId)
        {
            var pets = petservice.GetByBreed(breed);
            if (pets == null)
            {
                return NotFound();
            }
            return pets;
        }

        // GET: api/Pets/5/Vaccines
        [HttpGet("{id:int}/vaccines")]
        public async Task<ActionResult<IEnumerable<Vaccine>>> GetPetsVaccines(int id)
        {
            var vaccines = petservice.GetAllVaccines(id);
            if (vaccines == null)
            {
                return NotFound();
            }
            return vaccines;
        }

        // GET: api/Pets/OwnerId/5
        [HttpGet("/ownerid/{ownerId:int}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetsByOwnerId(int ownerId)
        {
            var pets = petservice.GetByOwnerId(ownerId);
            if (pets == null)
            {
                return NotFound();
            }
            return pets;
        }

        // GET: api/Pets/5
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pets = petservice.GetAllPets();
            if (pets == null)
            {
                return NotFound();
            }
            var pet = petservice.GetById(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        // PUT: api/Pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.ID)
            {
                return BadRequest();
            }

            try
            {
                petservice.EditPet(id, pet);
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }

        // POST: api/Pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            var pets = petservice.GetAllPets();
            if (pets == null)
            {
                return Problem("Entity set 'PetfyDbContext.Pets'  is null.");
            }
            try
            {
                petservice.AddPet(pet);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CreatedAtAction("GetPet", new { id = pet.ID }, pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(int id)
        {
            var pets = petservice.GetAllPets();
            if (pets == null)
            {
                return NotFound();
            }

            try
            {
                var deleteFlag = petservice.DeletePet(id);
                if (!deleteFlag)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return NoContent();
        }
    }
}
