using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class UserType
    {
        
        public int UserTypeId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public bool Status { get; set; }

        public DateTime Createdate { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
