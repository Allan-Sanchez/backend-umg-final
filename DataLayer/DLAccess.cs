using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLAccess
    {
        private UMGDBContext _context;
        public DLAccess(UMGDBContext context)
        {
            _context = context;
        }

        public List<Access> getAllAccess()
        {
            var accesses = _context.Access.Where(x=>x.Status==true).ToList();
            return accesses;
        }

        public Access GetAccessById(int id)
        {
            var access = _context.Access.Where(x => x.Status == true).FirstOrDefault(x => x.AccessId == id);
            return access;
        }


        public Access AddAccess(Access Access)
        {
            _context.Access.Add(Access);
            _context.SaveChanges();
            return Access;
        }

        public bool UpdateAccess(Access Access)
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
        public bool DeleteAccess(Access Access)
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
