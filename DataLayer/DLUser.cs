using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using BackendWebUMG.UtilityObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLUser
    {
        UMGDBContext _context;
        public DLUser(UMGDBContext Context)
        {
            _context = Context;
        }

        public List<User> GetAllUsers()
        {
            var user = _context.User.ToList();
            return user;
        }

        public User GetUserById(int id)
        {
            var user = _context.User.Include(x => x.Person).FirstOrDefault(x => x.UserId == id);
            return user;
        }


        public User addUser(User newUser)
        {

            newUser.Password = Security.Encrypt(newUser.Password);
            newUser.OldPassword = Security.Encrypt(newUser.Password);
            _context.User.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        public bool UpdateUser(User uUser)
        {
            try
            {
                uUser.Password = Security.Encrypt(uUser.Password);
                uUser.OldPassword = Security.Encrypt(uUser.Password); ;
                _context.Entry(uUser).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool DeleteUser(User deleteUser)
        {
            try
            {
                _context.Remove(deleteUser); //Literal
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
