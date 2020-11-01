using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class Course
    {
        
        public int CourseId { get; set; }

        public int FacultyId { get; set; }

        public int ProfessorId { get; set; }

        [StringLength(200)]
        public string CourseName { get; set; }

        [StringLength(10)]
        public string Section { get; set; }

        [StringLength(100)]
        public string ClassRoom { get; set; }

        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        [JsonIgnore]
        public Person Professor { get; set; }
        public ICollection<Activity> Activities { get; set; }
        public ICollection<CourseExam> CourseExams { get; set; }

    }
}
