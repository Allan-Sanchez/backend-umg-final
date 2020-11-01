using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class User
    {
        
        public int UserId { get; set; }

        public int PersonId { get; set; }

        [StringLength(100)]
        public string user { get; set; }

        [StringLength(100)]
        public string Password { get; set; }
        public string OldPassword { get; set; }
        public DateTime DateUpdate { get; set; }
        public Person Person { get; set; }

        public ICollection<TokenByUser> Tokens { get; set; }
    }
}
