using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using BackendWebUMG.DataLayer; 
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BackendWebUMG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly UMGDBContext _context;
        public ActivitiesController(UMGDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Activity>> GetAll()
        {
            DLActivity DLActivity = new DLActivity(_context);
            var accesses = DLActivity.getAllActivity();

            if (accesses == null)
            {
                return NotFound();
            }

            return accesses;
        }
        [HttpGet("{id}")]
        public ActionResult<Activity> GetById(int id)
        {
            DLActivity DLActivity = new DLActivity(_context);
            var role = DLActivity.GetActivityById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpGet("GetAllActivityTypes")]
        public ActionResult<List<ActivityType>> GetAllActivityTypes()
        {
            DLActivityType dlactivitytype = new DLActivityType(_context);
            var activitiestype = dlactivitytype.getAllActivityType();

            if (activitiestype == null)
            {
                return NotFound();
            }

            return activitiestype;
        }
        [HttpGet("GetActivityTypeById/{id}")]
        public ActionResult<ActivityType> GetActivityTypeById(int id)
        {
            DLActivityType dlActivityType = new DLActivityType(_context);
            var role = dlActivityType.GetActivityTypeById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

      
        [HttpPost]
        public ActionResult<Activity> Post([FromBody] Activity activity)
        {
            DLActivity DLActivity = new DLActivity(_context);
            var role = DLActivity.AddActivity(activity);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = activity.ActivityId }, activity);
        }


        [HttpPost("PostActivityType")]
        public ActionResult<ActivityType> PostActivityType([FromBody] ActivityType newActivityType)
        {
            DLActivityType dlActivityType = new DLActivityType(_context);
            var role = dlActivityType.AddActivityType(newActivityType);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newActivityType.ActivityTypeId }, newActivityType);
        }


      
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Activity uActivity)
        {
            if (id != uActivity.ActivityId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLActivity dlActivity = new DLActivity(_context);
            if (dlActivity.UpdateActivity(uActivity))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }

      
        [HttpPut("PutActivityType/{id}")]
        public ActionResult PutActivityType(int id, [FromBody] ActivityType uactivitytype)
        {
            if (id != uactivitytype.ActivityTypeId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLActivityType dlActivity = new DLActivityType(_context);
            if (dlActivity.UpdateActivityType(uactivitytype))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }


      
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DLActivity DLActivity = new DLActivity(_context);
            var facultydelete = DLActivity.GetActivityById(id);
            if (facultydelete == null)
            {
                return BadRequest("No Existe ningun Acceso");
            }

            if (DLActivity.DeleteActivity(facultydelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }


      
        [HttpDelete("DeleteActivityType/{id}")]
        public ActionResult DeleteActivityType(int id)
        {
            DLActivityType   dlActivitytype = new DLActivityType(_context);
            var facultydelete = dlActivitytype.GetActivityTypeById(id);
            if (facultydelete == null)
            {
                return BadRequest("No Existe ningun Acceso");
            }

            if (dlActivitytype.DeleteActivityType(facultydelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
    }
}
