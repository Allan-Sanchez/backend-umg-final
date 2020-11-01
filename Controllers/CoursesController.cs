using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class CoursesController : ControllerBase
    {

        private readonly UMGDBContext _context;
        public CoursesController(UMGDBContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<List<Course>> GetAll()
        {
            DLCourse dlCourse = new DLCourse(_context);
            var courses = dlCourse.getAllCourse();

            if (courses == null)
            {
                return NotFound();
            }

            return courses;
        }
        [HttpGet("{id}")]
        public ActionResult<Course> GetById(int id)
        {
            DLCourse dlCourse = new DLCourse(_context);
            var role = dlCourse.GetCourseById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpGet("GetAllCourseExam")]
        public ActionResult<List<CourseExam>> GetAllCourseExam()
        {
            DLCourseExam dlCourse = new DLCourseExam(_context);
            var courseexams = dlCourse.getAllCourseExams();

            if (courseexams == null)
            {
                return NotFound();
            }

            return courseexams;
        }
        [HttpGet("GetCourseExamById/{id}")]
        public ActionResult<CourseExam> GetCourseExamById(int id)
        {
            DLCourseExam dlCourseExam = new DLCourseExam(_context);
            var role = dlCourseExam.GetCourseExamById(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        [HttpGet("GetAllTypeExam")]
        public ActionResult<List<ExamType>> GetAllTypeExam()
        {
            DLTypeExam dlTypeexam = new DLTypeExam(_context);
            var typeexams = dlTypeexam.getAllExamType();

            if (typeexams == null)
            {
                return NotFound();
            }

            return typeexams;
        }
        [HttpGet("GetTypeExamById/{id}")]
        public ActionResult<ExamType> GetTypeExamById(int id)
        {
            DLTypeExam dltypeexam = new DLTypeExam(_context);
            var typexam = dltypeexam.GetExamTypeById(id);

            if (typexam == null)
            {
                return NotFound();
            }

            return typexam;
        }

      
        [HttpPost]
        public ActionResult<Course> Post([FromBody] Course newCourse)
        {
            DLCourse dlCourseexam = new DLCourse(_context);
            var role = dlCourseexam.AddCourse(newCourse);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newCourse.CourseId }, newCourse);
        }
      
        [HttpPost("PostCourseExam")]
        public ActionResult<Course> PostCourseExam([FromBody] CourseExam newCourseExam)
        {
            DLCourseExam dlCourse = new DLCourseExam(_context);
            var role = dlCourse.AddCourseExam(newCourseExam);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = newCourseExam.CourseExamId }, newCourseExam);
        }

        [HttpPost("PostExamType")]
        public ActionResult<Course> PostExamType([FromBody] ExamType typeexam)
        {
            DLTypeExam dltypeexam = new DLTypeExam(_context);
            var role = dltypeexam.AddExamType(typeexam);

            if (role == null)
            {
                return NotFound();
            }

            return CreatedAtAction(nameof(GetById), new { id = typeexam.ExamTypeId }, typeexam);
        }

      
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Course uCourse)
        {
            if (id != uCourse.CourseId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLCourse dlfalculty = new DLCourse(_context);
            if (dlfalculty.UpdateCourse(uCourse))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }
      
        [HttpPut("PutCourseExam/{id}")]
        public ActionResult PutCourseExam(int id, [FromBody] CourseExam uCourseExam)
        {
            if (id != uCourseExam.CourseExamId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLCourseExam dlfalculty = new DLCourseExam(_context);
            if (dlfalculty.UpdateCourseExam(uCourseExam))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }

        [HttpPut("PutExamType/{id}")]
        public ActionResult PutExamType(int id, [FromBody] ExamType uexamtype)
        {
            if (id != uexamtype.ExamTypeId)
            {
                return BadRequest("Los identificadores no Coinciden");
            }

            DLTypeExam dlfalculty = new DLTypeExam(_context);
            if (dlfalculty.UpdateExamType(uexamtype))
            {
                return NoContent();
            }
            else return BadRequest("Error de Actualizacion");
        }

      
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            DLCourse dlCourse = new DLCourse(_context);
            var Coursedelete = dlCourse.GetCourseById(id);
            if (Coursedelete == null)
            {
                return BadRequest("No Existe ningun Acceso");
            }

            if (dlCourse.DeleteCourse(Coursedelete))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
      
        [HttpDelete("DeleteCouseExam/{id}")]
        public ActionResult DeleteCouseExam(int id)
        {
            DLCourseExam dlcoruseexam = new DLCourseExam(_context);
            var courseexam = dlcoruseexam.GetCourseExamById(id);
            if (courseexam == null)
            {
                return BadRequest("No Existe ningun Acceso");

            }

            if (dlcoruseexam.DeleteCourseExam(courseexam))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }

      
        [HttpDelete("DeleteExamType/{id}")]
        public ActionResult DeleteExamType(int id)
        {
            DLTypeExam dlexamtype = new DLTypeExam(_context);
            var deleteexamtype = dlexamtype.GetExamTypeById(id);
            if (deleteexamtype == null)
            {
                return BadRequest("No Existe ningun Acceso");
            }

            if (dlexamtype.DeleteExamType(deleteexamtype))
            {
                return NoContent();
            }
            else return BadRequest("Error al Eliminar");
        }
    }
}
