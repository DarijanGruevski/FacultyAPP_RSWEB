#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FacultyApp_RSWEB.Models;

namespace FacultyApp_RSWEB.Data
{
    public class FacultyApp_RSWEBContext : DbContext
    {
        public FacultyApp_RSWEBContext (DbContextOptions<FacultyApp_RSWEBContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Student { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Enrollment> Enrollment { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Enrollment>()
             .HasOne<Student>(p => p.student)
             .WithMany(p => p.Courses)
             .HasForeignKey(p => p.studentId);

            //.HasPrincipalKey(p => p.Id);
            builder.Entity<Enrollment>()
            .HasOne<Course>(p => p.course)
            .WithMany(p => p.Students)
            .HasForeignKey(p => p.CourseId);
            //.HasPrincipalKey(p => p.Id);

            builder.Entity<Course>()
            .HasOne<Teacher>(p => p.FirstTeacher)
            .WithMany(p => p.Courses1)
            .HasForeignKey(p => p.FirstTeacherId);
            //.HasPrincipalKey(p => p.Id);

            builder.Entity<Course>()
           .HasOne<Teacher>(p => p.SecondTeacher)
           .WithMany(p => p.Courses2)
           .HasForeignKey(p => p.SecondTeacherId);
            //.HasPrincipalKey(p => p.Id);
        }

        public DbSet<Teacher> Teacher { get; set; }
    }
}
