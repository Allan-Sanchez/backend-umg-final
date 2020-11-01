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
    public class UsersController : ControllerBase
    {
        private readonly UMGDBContext _context;
        public UsersController(UMGDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            DLUser dlUser = new DLUser(_context);
            var persons = dlUser.GetAllUsers();

            if (persons == null)
            {
                return NotFound();
            }

            return persons;
        }
        [HttpGet("{id}")]
        public ActionResult<User> GetById(int id)
        {
            DLUser DLUser = new DLUser(_context);
            var user = DLUser.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public ActionResult<User> Post([FromBody] User newUser)
        {
            DLUser DLUser = new DLUser(_context);
            var person = DLUser.addUser(newUser);

            if (person == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newUser.UserId }, newUser);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] User uUser)
        {
            if (id != uUser.UserId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLUser rol = new DLUser(_context);
            if (rol.UpdateUser(uUser))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DLUser DLUser = new DLUser(_context);
            var personDelete = DLUser.GetUserById(id);
            if (personDelete == null)
            {
                return BadRequest("No Existe ninguna persona");
            }

            if (DLUser.DeleteUser(personDelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
    }
}
