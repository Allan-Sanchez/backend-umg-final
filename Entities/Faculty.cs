using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class Faculty
    {
        
        public int FacultyId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public ICollection<CoordinatorByFaculty> FacultyCoordinators { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
