using BackendWebUMG.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.UtilityObjects
{
    public class UserWithToken:User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(User User)
        {
            this.UserId = User.UserId;
            this.user = User.user;
            this.Password = User.Password;
            this.OldPassword = User.OldPassword;
            this.Person = User.Person; 
        }

    }
}
