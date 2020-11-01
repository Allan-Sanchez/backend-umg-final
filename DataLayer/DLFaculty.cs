using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLFaculty
    {
        private UMGDBContext _context;
        public DLFaculty(UMGDBContext context)
        {
            _context = context;
        }

        public List<Faculty> getAllFaculty()
        {
            var faculties = _context.Faculty.Where(x => x.Status == true).ToList();
            return faculties;
        }

        public Faculty GetFacultyById(int id)
        {
            var Faculty = _context.Faculty.Where(x => x.Status == true).Include(x=>x.Courses).FirstOrDefault(x => x.FacultyId == id);
            return Faculty;
        }


        public Faculty AddFaculty(Faculty Faculty)
        {
            _context.Faculty.Add(Faculty);
            _context.SaveChanges();
            return Faculty;
        }

        public bool UpdateFaculty(Faculty Faculty)
        {
            try
            {
                _context.Entry(Faculty).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteFaculty(Faculty Faculty)
        {
            try
            {
                Faculty.Status = false; //LogicDelete
                _context.Entry(Faculty).State = EntityState.Modified;
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
