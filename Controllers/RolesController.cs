using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendWebUMG.Contexts;
using BackendWebUMG.DataLayer;
using BackendWebUMG.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BackendWebUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UMGDBContext _context;
        public RolesController(UMGDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<List<Rol>> GetAll()
        {
            DLRol rol = new DLRol(_context);
            var roles = rol.GetAllRoles();

            if (roles == null)
            {
                return NotFound();
            }

            return roles;
        }
        [HttpGet("{id}")]
        public ActionResult<Rol> GetById(int id)
        {
            DLRol rol = new DLRol(_context);
            var role = rol.GetRolById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpGet("GetAllAccessByRol")]
        public ActionResult<List<AccessByRol>> GetAllAccessByRol()
        {
            DLAccessByRol accessesbyrol = new DLAccessByRol(_context);
            var accesses = accessesbyrol.GetAllAccessByRol();

            if (accesses == null)
            {
                return NotFound();
            }

            return accesses;
        }
        [HttpGet("GetAccessByRol/{id}")]
        public ActionResult<AccessByRol> GetAccessByRol(int id)
        {
            DLAccessByRol daccess = new DLAccessByRol(_context);
            var access = daccess.GetAccessByRolById(id);

            if (access == null)
            {
                return NotFound();
            }

            return access;
        }

       

        [HttpPost]
        public ActionResult<Rol> Post([FromBody] Rol newRol)
        {
            DLRol rol = new DLRol(_context);
            var role = rol.AddRol(newRol);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newRol.RolId }, newRol);
        }

        [HttpPost("PostAccessByRol")]
        public ActionResult<AccessByRol> PostAddAccessByRol([FromBody] AccessByRol accessbyrol)
        {
            DLAccessByRol rol = new DLAccessByRol(_context);
            var role = rol.AddAccessByRol(accessbyrol);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = accessbyrol.RolId }, accessbyrol);
        }

        

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Rol newRol)
        {
            if (id != newRol.RolId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLRol rol = new DLRol(_context);
            if (rol.updateRol(newRol))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }

        [HttpPut("PutAccessByRol/{id}")]
        public ActionResult PutAccessByRol(int id, [FromBody] AccessByRol newAccess)
        {
            if (id != newAccess.RolId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLAccessByRol accessbyrol = new DLAccessByRol(_context);
            if (accessbyrol.UpdateAccess(newAccess))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DLRol rol = new DLRol(_context);
            var roldelete = rol.GetRolById(id);
            if (roldelete == null)
            {
                return BadRequest("No Existe ningun Rol");
            }

            if (rol.DeleteRol(roldelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }

        [HttpDelete("DeleteAccessByRol/{id}")]
        public ActionResult DeleteAccessByRol(int id)
        {
            DLAccessByRol accessbyrol = new DLAccessByRol(_context);
            var roldelete = accessbyrol.GetAccessByRolById(id);
            if (roldelete == null)
            {
                return BadRequest("No Existe ningun Rol");
            }

            if (accessbyrol.DeleteAccess(roldelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
    }
}

