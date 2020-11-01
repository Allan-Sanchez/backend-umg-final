using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class ActivityType
    {
        
        public int ActivityTypeId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public ICollection<Activity> Activities { get; set; }
    }
}
