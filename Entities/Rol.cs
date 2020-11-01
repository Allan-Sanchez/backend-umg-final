using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class Rol
    {
        
        public int RolId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<AccessByRol> Accesses { get; set; }

        public ICollection <Person> Persons { get; set; }
    }
}
