using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Numerics;
using System.Runtime;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class Activity
    {
        
        public Int64 ActivityId { get; set; }

        public int ActivityType { get; set; }

        public int CourseId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(-1)]
        public string Note { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Course Course { get; set; }
        public ActivityType ActivityT { get; set; }

    }
}
