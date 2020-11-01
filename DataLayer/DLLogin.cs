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
    public class DLLogin
    {
        UMGDBContext context; 

        public DLLogin(UMGDBContext Context)
        {
            context = Context; 
        }

        public User FindUser(User User)
        {
            User CompleteUser = null;

            CompleteUser = context.User.Include(x => x.Person)
               .Where(x => x.user == User.user
               && x.Password == Security.Encrypt(User.Password)).FirstOrDefault();

            return CompleteUser;
        }
    }
}
