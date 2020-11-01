using BackendWebUMG.DataLayer;
using BackendWebUMG.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendWebUMG.Contexts
{
    public class UMGDBContext : DbContext
    {
        public UMGDBContext(DbContextOptions<UMGDBContext> options) : base(options)
        {
        }

        public DbSet<Rol> Rol { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Access> Access { get; set; }
        public DbSet<AccessByRol> accessByRol { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<CourseExam> CourseExam { get; set; }
        public DbSet<ExamType> ExamType { get; set; }
        public DbSet<Faculty> Faculty { get; set; } 
        public DbSet<CoordinatorByFaculty> coordinatorByFaculty { get; set; }
        public DbSet<TokenByUser> tokenByUser { get; set; }

    }
}
