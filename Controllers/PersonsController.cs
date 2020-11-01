using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendWebUMG.Contexts;
using BackendWebUMG.DataLayer;
using BackendWebUMG.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackendWebUMG.Controllers
{
  
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {

        private readonly UMGDBContext _context;
        public PersonsController(UMGDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            DLPerson dlperson = new DLPerson(_context);
            var persons = dlperson.GetAllPersons();

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }
        [HttpGet("{id}")]
        public ActionResult<Person> GetById(int id)
        {
            DLPerson dlperson = new DLPerson(_context);
            var person = dlperson.GetPersonById(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        [HttpPost]
        public ActionResult<Person> Post([FromBody] Person newPerson)
        {
            DLPerson dlperson = new DLPerson(_context);
            var person = dlperson.AddPerson(newPerson);

            if (person == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newPerson.personId }, newPerson);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Person uPerson)
        {
            if (id != uPerson.personId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLPerson rol = new DLPerson(_context);
            if (rol.UpdatePerson(uPerson))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DLPerson dlperson = new DLPerson(_context);
            var personDelete = dlperson.GetPersonById(id);
            if (personDelete == null)
            {
                return BadRequest("No Existe ninguna persona");
            }

            if (dlperson.DeletePerson(personDelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
}
}
