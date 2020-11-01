using BackendWebUMG.Contexts;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.DataLayer
{
    public class DLActivity
    {
        private UMGDBContext _context;
        public DLActivity(UMGDBContext context)
        {
            _context = context;
        }

        public List<Activity> getAllActivity()
        {
            var Activities = _context.Activity.Where(x => x.EndDate <= DateTime.Now).ToList();
            return Activities;
        }

        public Activity GetActivityById(int id)
        {
            var Activity = _context.Activity.Where(x => x.EndDate <= DateTime.Now).Include(x => x.ActivityType).FirstOrDefault(x => x.ActivityId == id);
            return Activity;
        }


        public Activity AddActivity(Activity Activity)
        {
            _context.Activity.Add(Activity);
            _context.SaveChanges();
            return Activity;
        }

        public bool UpdateActivity(Activity Activity)
        {
            try
            {
                _context.Entry(Activity).State = EntityState.Modified;
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DeleteActivity(Activity Activity)
        {
            try
            {
               
                _context.Remove(Activity); 
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
