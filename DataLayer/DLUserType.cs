using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLUserType
    {
        private UMGDBContext _context; 
        public DLUserType(UMGDBContext context)
        {
            _context = context; 
        }

        public List<UserType> getAllUserTypes()
        {
            var UserTypes = _context.UserType.Where(x => x.Status == true).ToList();
            return UserTypes; 
        }

        public UserType GetUserTypeById(int id)
        {
            var utype = _context.UserType.Where(x => x.Status == true).FirstOrDefault(x => x.UserTypeId == id);
            return utype;
        }


        public UserType AddUserType(UserType usertype)
        {
            _context.UserType.Add(usertype);
            _context.SaveChanges();
            return usertype;
        }

        public bool updateUserType(UserType userType)
        {
            try
            {
                _context.Entry(userType).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteUserType(UserType userType)
        {
            try
            {
                userType.Status = false; //LogicDelete
                _context.Entry(userType).State = EntityState.Modified;
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
