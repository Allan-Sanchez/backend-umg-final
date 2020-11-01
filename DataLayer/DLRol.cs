using BackendWebUMG.Contexts;
using BackendWebUMG.Controllers;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLRol
    {
        private UMGDBContext _context;

        public DLRol(UMGDBContext Context)
        {
            _context = Context;
        }

        public List<Rol> GetAllRoles()
        {
            var Roles = _context.Rol.Where(x => x.Status == true).ToList();
            return Roles;
        }

        public List<Access> getAccessByRol(int id)
        {
            var Accesses = (from roles in _context.Rol
                                        join AccessByRol in _context.accessByRol
                                        on roles.RolId equals AccessByRol.RolId
                                        join accesses in _context.Access
                                        on AccessByRol.AccessId equals accesses.AccessId
                            where roles.RolId == id
                                        select new Access
                                        {
                                            AccessId = accesses.AccessId,
                                            TopAccess =  accesses.TopAccess,
                                            Status =  accesses.Status,
                                            Name = accesses.Name,
                                            URL = accesses.URL,
                                            Control = accesses.Control,
                                            CreateDate = accesses.CreateDate
                                        }).ToList();

            return Accesses; 
        }

        public Rol GetRolById(int id)
        {
            var rol = _context.Rol.Where(x => x.Status == true).Include(x=>x.Accesses).FirstOrDefault(x => x.RolId == id);
            return rol;
        }


        public Rol AddRol(Rol newRol)
        {
            _context.Rol.Add(newRol);
            _context.SaveChanges();
            return newRol;
        }

        public bool updateRol(Rol newRol)
        {
            try
            {
                _context.Entry(newRol).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteRol(Rol deleteRol)
        {
            try
            {
                deleteRol.Status = false; //LogicDelete
                _context.Entry(deleteRol).State = EntityState.Modified;
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
