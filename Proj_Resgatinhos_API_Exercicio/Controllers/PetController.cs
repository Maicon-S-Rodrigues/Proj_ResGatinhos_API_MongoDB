using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj_Resgatinhos_API_Exercicio.Models;
using Proj_Resgatinhos_API_Exercicio.Services;
using System.Collections.Generic;

namespace Proj_Resgatinhos_API_Exercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly PetService _petService;
        private readonly PersonService _personService;
        public PetController(PetService petService, PersonService personService)
        {
            _petService = petService;
            _personService = personService;
        }



        [HttpGet]
        public ActionResult<List<Pet>> Get() => _petService.Get();



        [HttpGet("Name/{name}", Name = "GetByName")]
        public ActionResult<Pet> GetByName(string name)
        {
            var pets = _petService.Get();

            foreach (var pet in pets)
            {
                if (pet.Name == name)
                {
                    return Ok(pet);
                }
            }
            return NotFound();
        }




        [HttpPost]
        public ActionResult<Pet> CreatePet(Pet pet)
        {
            //Person person = _personService.Create(pet.Person);
            //pet.Person = person;

            _petService.Create(pet);

            return Ok(pet);
        }


        [HttpPut]
        public ActionResult<Pet> Update(Pet petIn, string id)
        {
            var pet = _petService.Get(id);
            if (pet == null)
                return NotFound();

            Person person = new();
            if (petIn.Person.Id == null)
            {
                person = _personService.Create(petIn.Person);
            }
            else
            {
                person = _personService.Get(petIn.Person.Id);
            }

            pet.Person = person;


            _petService.Update(pet, id);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var pet = _petService.Get(id);
            if (pet == null)
                return NotFound();

            _petService.Remove(pet);
            return NoContent();
        }


        [HttpDelete("Adopter/{petId}/{adopterId}")]
        public ActionResult DeleteAdopter(string petId, string adopterId)
        {
            var pet = _petService.Get(petId);
            if (pet == null)
                return NotFound();

            var adopter = _personService.Get(adopterId);
            if (adopter == null)
                return NotFound();

            pet.Person = null;
            _petService.Update(pet, petId);
            return NoContent();
        }
    }
}
