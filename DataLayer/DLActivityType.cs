using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLActivityType
    {
        private UMGDBContext _context;
        public DLActivityType(UMGDBContext context)
        {
            _context = context;
        }

        public List<ActivityType> getAllActivityType()
        {
            var ActivityTypes = _context.ActivityType.Where(x=>x.Status==true).ToList();
            return ActivityTypes;
        }

        public ActivityType GetActivityTypeById(int id)
        {
            var ActivityType = _context.ActivityType.Where(x => x.Status == true).FirstOrDefault(x => x.ActivityTypeId == id);
            return ActivityType;
        }


        public ActivityType AddActivityType(ActivityType ActivityType)
        {
            _context.ActivityType.Add(ActivityType);
            _context.SaveChanges();
            return ActivityType;
        }

        public bool UpdateActivityType(ActivityType ActivityType)
        {
            try
            {
                _context.Entry(ActivityType).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteActivityType(ActivityType ActivityType)
        {
            try
            {

                _context.Remove(ActivityType);
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
