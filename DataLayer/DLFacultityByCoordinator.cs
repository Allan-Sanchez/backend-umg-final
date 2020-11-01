using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLFacultityByCoordinator
    {
        private UMGDBContext _context;
        public DLFacultityByCoordinator(UMGDBContext context)
        {
            _context = context;
        }

        public List<CoordinatorByFaculty> getAllFacultity()
        {
            var accesses = _context.coordinatorByFaculty.Where(x=>x.Status==true).ToList();
            return accesses;
        }

        public CoordinatorByFaculty GetFacultityByCoordinatorById(int id)
        {
            var FacultityByCoordinator = _context.coordinatorByFaculty.Where(x => x.Status == true).Include(x=>x.Coordinator).FirstOrDefault(x => x.CoordinatorByFacultyId == id);
            return FacultityByCoordinator;
        }

        public CoordinatorByFaculty AddCoordinatorByFaculty(CoordinatorByFaculty newCoordinator)
        {
            _context.coordinatorByFaculty.Add(newCoordinator);
            _context.SaveChanges();
            return newCoordinator;
        }

        public bool UpdateCoordinatorByFaculty(CoordinatorByFaculty uCoordinator)
        {
            try
            {
                _context.Entry(uCoordinator).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCoordinator(CoordinatorByFaculty deleteCoordinator)
        {
            try
            {
                deleteCoordinator.Status = false; //LogicDelete
                _context.Entry(deleteCoordinator).State = EntityState.Modified;
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
