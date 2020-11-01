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
    public class AccessController : ControllerBase
    {
        private readonly UMGDBContext _context;
        public AccessController(UMGDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Access>> GetAll()
        {
            DLAccess ac = new DLAccess(_context);
            var accesses = ac.getAllAccess();

            if (accesses == null)
            {
                return NotFound();
            }

            return accesses;
        }
        [HttpGet("{id}")]
        public ActionResult<Access> GetById(int id)
        {
            DLAccess ac = new DLAccess(_context);
            var role = ac.GetAccessById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpPost]
        public ActionResult<Rol> Post([FromBody] Access newAccess)
        {
            DLAccess ac = new DLAccess(_context);
            var role = ac.AddAccess(newAccess);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newAccess.AccessId }, newAccess);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Access newAccess)
        {
            if (id != newAccess.AccessId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLAccess rol = new DLAccess(_context);
            if (rol.UpdateAccess(newAccess))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DLAccess ac = new DLAccess(_context);
            var accessdelete = ac.GetAccessById(id);
            if (accessdelete == null)
            {
                return BadRequest("No Existe ningun Acceso");
            }

            if (ac.DeleteAccess(accessdelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
    }
}
