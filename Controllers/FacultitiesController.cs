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
    public class FacultitiesController : ControllerBase
    {
        private readonly UMGDBContext _context;
        public FacultitiesController(UMGDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Faculty>> GetAll()
        {
            DLFaculty dlFaculty = new DLFaculty(_context);
            var accesses = dlFaculty.getAllFaculty();

            if (accesses == null)
            {
                return NotFound();
            }

            return accesses;
        }
        [HttpGet("{id}")]
        public ActionResult<Faculty> GetById(int id)
        {
            DLFaculty dlFaculty = new DLFaculty(_context);
            var role = dlFaculty.GetFacultyById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpGet("GetAllCoordinators")]
        public ActionResult<List<CoordinatorByFaculty>> GetAllCoordinatorByFaculty()
        {
            DLFacultityByCoordinator dlFaculty = new DLFacultityByCoordinator(_context);
            var accesses = dlFaculty.getAllFacultity();

            if (accesses == null)
            {
                return NotFound();
            }

            return accesses;
        }
        [HttpGet("GetCoordinatorById/{id}")]
        public ActionResult<CoordinatorByFaculty> GetCoordinatorById(int id)
        {
            DLFacultityByCoordinator dlFaculty = new DLFacultityByCoordinator(_context);
            var role = dlFaculty.GetFacultityByCoordinatorById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }
      
        [HttpPost]
        public ActionResult<Faculty> Post([FromBody] Faculty newFaculty)
        {
            DLFaculty dlfaculty = new DLFaculty(_context);
            var role = dlfaculty.AddFaculty(newFaculty);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newFaculty.FacultyId }, newFaculty);
        }
      
        [HttpPost("PostCoordinator")]
        public ActionResult<Faculty> PostCoordinator([FromBody] CoordinatorByFaculty newCoordinator)
        {
            DLFacultityByCoordinator dlfaculty = new DLFacultityByCoordinator(_context);
            var role = dlfaculty.AddCoordinatorByFaculty(newCoordinator);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newCoordinator.CoordinatorByFacultyId }, newCoordinator);
        }
      
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Faculty uFaculty)
        {
            if (id != uFaculty.FacultyId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLFaculty dlfalculty = new DLFaculty(_context);
            if (dlfalculty.UpdateFaculty(uFaculty))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }
      
        [HttpPut("putCoordinator/{id}")]
        public ActionResult PutCoordinator(int id, [FromBody] CoordinatorByFaculty ucoordinator)
        {
            if (id != ucoordinator.CoordinatorByFacultyId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLFacultityByCoordinator dlfalculty = new DLFacultityByCoordinator(_context);
            if (dlfalculty.UpdateCoordinatorByFaculty(ucoordinator))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }

      
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DLFaculty dlfaculty = new DLFaculty(_context);
            var facultydelete = dlfaculty.GetFacultyById(id);
            if (facultydelete == null)
            {
                return BadRequest("No Existe ningun Acceso");
            }

            if (dlfaculty.DeleteFaculty(facultydelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
      
        [HttpDelete("DeleteCoordinator/{id}")]
        public ActionResult DeleteCoordinator(int id)
        {
            DLFacultityByCoordinator dlfaculty = new DLFacultityByCoordinator(_context);
            var coordinatorDelete = dlfaculty.GetFacultityByCoordinatorById(id);
            if (coordinatorDelete == null)
            {
                return BadRequest("No Existe ningun Acceso");
            }

            if (dlfaculty.DeleteCoordinator(coordinatorDelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
    }
}
