using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Application.Entities
{
    public class AttendanceContext : DbContext
    {
            public AttendanceContext() : base("AttendanceContextConnection") // AttendanceContextConnection le nom de la connection a configurer dans web config
                                                                             // il faut creer connectionStrings
        {

        }

        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<ClassRoom> ClassRoom { get; set; }
        public DbSet<Student> Student { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}