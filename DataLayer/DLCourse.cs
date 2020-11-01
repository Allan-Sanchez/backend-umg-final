using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLCourse
    {
        private UMGDBContext _context;
        public DLCourse(UMGDBContext context)
        {
            _context = context;
        }

        public List<Course> getAllCourse()
        {
            var courses = _context.Course.ToList();
            return courses;
        }

        public Course GetCourseById(int id)
        {
            var Course = _context.Course.Include(x => x.Professor).FirstOrDefault(x => x.CourseId == id);
            return Course;
        }


        public Course AddCourse(Course Course)
        {
            _context.Course.Add(Course);
            _context.SaveChanges();
            return Course;
        }

        public bool UpdateCourse(Course Course)
        {
            try
            {
                _context.Entry(Course).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCourse(Course Course)
        {
            try
            {

                _context.Remove(Course);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
