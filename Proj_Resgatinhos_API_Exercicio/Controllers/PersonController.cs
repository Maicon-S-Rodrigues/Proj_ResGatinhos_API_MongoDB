using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proj_Resgatinhos_API_Exercicio.Models;
using Proj_Resgatinhos_API_Exercicio.Services;
using System.Collections.Generic;

namespace Proj_Resgatinhos_API_Exercicio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly AddressService _addressService;
        public PersonController(PersonService personService, AddressService addressService)
        {
            _personService = personService;
            _addressService = addressService;
        }


        [HttpGet]
        public ActionResult<List<Person>> Get() => _personService.Get();


        [HttpGet("GetByPersonId/{id:length(24)}")]
        public ActionResult<Person> GetById(string id)
        {
            var person = _personService.Get(id);
            if (person == null)
                return NotFound();

            return person;
        }


        [HttpGet("GetByAddressId/{addressId:length(24)}")]
        public ActionResult<Person> GetByAddress(string addressId)
        {
            var people = _personService.Get();

            foreach (var person in people)
            {
                if (person.Address.Id == addressId)
                {
                    return Ok(person);
                }
            }
            return NotFound();
        }

        [HttpGet("GetByName")]
        public ActionResult<Person> GetByName(string personName)
        {
            var people = _personService.Get();

            foreach (var person in people)
            {
                if (person.Name == personName)
                {
                    return Ok(person);
                }
            }
            return NotFound();
        }


        [HttpPost]
        public ActionResult<Person> Create(Person person)
        {
            //Address address = _addressService.Create(person.Address);
            //person.Address = address;

            _personService.Create(person);
            return Ok(person);
        }


        [HttpPut]
        public ActionResult<Person> Update(Person personIn, string id)
        {
            var person = _personService.Get(id);
            if (person == null)
                return NotFound();

            Address address = _addressService.Create(personIn.Address);
            person.Address = address;


            _personService.Update(personIn, id);

            return NoContent();
        }


        [HttpDelete]
        public ActionResult Delete(string id)
        {
            var person = _personService.Get(id);
            if (person == null)
                return NotFound();

            _personService.Remove(person);
            return NoContent();
        }
    }
}
