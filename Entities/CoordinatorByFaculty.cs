using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class CoordinatorByFaculty
    {
        public int CoordinatorByFacultyId { get; set; }

        [StringLength(200)]
        public int FacultyId { get; set; }

        public int CoordinatorId { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public Faculty Faculty { get; set; }
        [JsonIgnore]
        public Person Coordinator { get; set; }
    }
}
