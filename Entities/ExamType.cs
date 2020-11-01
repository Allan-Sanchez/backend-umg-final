using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class ExamType
    {
        
        public int ExamTypeId { get; set; }

        [StringLength(300)]
        public string Name { get; set; }

        public bool Status { get; set; }

        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        public ICollection<CourseExam> Exams { get; set; }

    }
}
