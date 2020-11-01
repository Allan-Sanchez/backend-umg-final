using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class AccessByRol
    {
        
        public int AccessByRolId { get; set; }
            
        public int RolId { get; set; }

        public int AccessId { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public Rol Rol { get; set; }
        [JsonIgnore]
        public Access Access { get; set; }
    }
}
