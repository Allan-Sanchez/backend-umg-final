using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLTypeExam
    {
        private UMGDBContext _context;
        public DLTypeExam(UMGDBContext context)
        {
            _context = context;
        }

        public List<ExamType> getAllExamType()
        {
            var ExamTypes = _context.ExamType.Where(x => x.Status == true).ToList();
            return ExamTypes;
        }

        public ExamType GetExamTypeById(int id)
        {
            var ExamType = _context.ExamType.Where(x => x.Status == true).FirstOrDefault(x => x.ExamTypeId == id);
            return ExamType;
        }


        public ExamType AddExamType(ExamType ExamType)
        {
            _context.ExamType.Add(ExamType);
            _context.SaveChanges();
            return ExamType;
        }

        public bool UpdateExamType(ExamType ExamType)
        {
            try
            {
                _context.Entry(ExamType).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteExamType(ExamType ExamType)
        {
            try
            {
                ExamType.Status = false; //LogicDelete
                _context.Entry(ExamType).State = EntityState.Modified;
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
