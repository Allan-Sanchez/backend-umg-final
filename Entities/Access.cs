using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class Access
    {
        
        public int AccessId { get; set; }
        public int? TopAccess { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(-1)]
        public string URL { get; set; }

        [StringLength(150)]
        public string Control { get; set; }

        public bool Status { get; set; }
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public ICollection<AccessByRol> AccessByRol { get; set; }

    }
}
