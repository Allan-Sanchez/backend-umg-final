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
    public class UserTypesController : ControllerBase
    {
        private readonly UMGDBContext _context;
        public UserTypesController(UMGDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<UserType>> GetAll()
        {
            DLUserType uType = new DLUserType(_context);
            var Utypes = uType.getAllUserTypes();

            if (Utypes == null)
            {
                return NotFound();
            }

            return Utypes;
        }
        [HttpGet("{id}")]
        public ActionResult<UserType> GetById(int id)
        {
            DLUserType utype = new DLUserType(_context);
            var usertype = utype.GetUserTypeById(id);

            if (usertype == null)
            {
                return NotFound();
            }

            return usertype;
        }

        [HttpPost]
        public ActionResult<Rol> Post([FromBody] UserType nUserType)
        {
            DLUserType utype = new DLUserType(_context);
            var userType = utype.AddUserType(nUserType);

            if (userType == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = nUserType.UserTypeId }, nUserType);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] UserType uUsertype)
        {
            if (id != uUsertype.UserTypeId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLUserType utype = new DLUserType(_context);
            if (utype.updateUserType(uUsertype))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DLUserType utype = new DLUserType(_context);
            var udelete = utype.GetUserTypeById(id);
            if (udelete == null)
            {
                return BadRequest("No Existe ningun Tipo de usuario");
            }

            if (utype.DeleteUserType(udelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }

    }
}
