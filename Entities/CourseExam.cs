using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Entities
{
    public class CourseExam
    {
        
        public Int64 CourseExamId { get; set; }

        public int CourseId { get; set; }

        public int ExamTypeId { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [StringLength(-1)]
        public string Note { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public ExamType ExamType { get; set; }
        public Course Course { get; set; }


    }
}
