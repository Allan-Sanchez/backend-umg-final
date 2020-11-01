using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLAccessByRol
    {
        private UMGDBContext _context;

        public DLAccessByRol(UMGDBContext Context)
        {
            _context = Context;
        }

        public AccessByRol AddAccessByRol(AccessByRol newAccess)
        {
            _context.accessByRol.Add(newAccess);
            _context.SaveChanges();
            return newAccess;
        }

        public List<AccessByRol> GetAllAccessByRol()
        {
            var accessesbyrol = _context.accessByRol.Include(x=>x.Access).Where(x => x.Status == true).ToList();
            return accessesbyrol;
        }

        public AccessByRol GetAccessByRolById(int id)
        {
            var access = _context.accessByRol.Where(x => x.Status == true).FirstOrDefault(x => x.AccessByRolId == id);
            return access;
        }
        public bool UpdateAccess(AccessByRol Access)
        {
            try
            {
                _context.Entry(Access).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteAccess(AccessByRol Access)
        {
            try
            {
                Access.Status = false; //LogicDelete
                _context.Entry(Access).State = EntityState.Modified;
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
