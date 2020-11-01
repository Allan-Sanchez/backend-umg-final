using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLCourseExam
    {
        private UMGDBContext _context;
        public DLCourseExam(UMGDBContext context)
        {
            _context = context;
        }

        public List<CourseExam> getAllCourseExams()
        {
            var exams = _context.CourseExam.Where(x => x.EndDate <= DateTime.Now).ToList();
            return exams;
        }

        public CourseExam GetCourseExamById(int id)
        {
            var exam = _context.CourseExam.Where(x => x.EndDate <= DateTime.Now).Include(x=>x.ExamType).FirstOrDefault(x => x.CourseExamId == id);
            return exam;
        }


        public CourseExam AddCourseExam(CourseExam exam)
        {
            _context.CourseExam.Add(exam);
            _context.SaveChanges();
            return exam;
        }

        public bool UpdateCourseExam(CourseExam exam)
        {
            try
            {
                _context.Entry(exam).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteCourseExam(CourseExam Exam)
        {
            try
            {
                _context.Remove(Exam);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
