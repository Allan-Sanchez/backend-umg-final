using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BackendWebUMG.Entities
{
    public class Person
    {
        
        public int personId { get; set; }

        public int UserTypeId { get; set; }

        public int RolId { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(12)]
        public string Phone { get; set; }
        [StringLength(75)]
        public string Email { get; set; }

        public DateTime Birthdate { get; set; }

        [StringLength(250)]
        public string AcademicLevel { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }

        public Rol Rol { get; set; }
        public  UserType UserTipe { get; set; }
        [JsonIgnore]
        public ICollection<User> Users { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<CoordinatorByFaculty> FacultityCordinator { get; set; }


    }
}
