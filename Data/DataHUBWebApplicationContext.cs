using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataHUBWebApplication.Models;

namespace DataHUBWebApplication.Data
{
    public class DataHUBWebApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        public DataHUBWebApplicationContext (DbContextOptions<DataHUBWebApplicationContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the entity mappings and relationships
            modelBuilder.Entity<Student>().HasKey(s => s.Id);
            modelBuilder.Entity<Course>().HasKey(c => c.Id);
            modelBuilder.Entity<Instructor>().HasKey(i => i.Id);

            // Configure other entity properties and relationships

            base.OnModelCreating(modelBuilder);
        }

        // Add other methods and properties as needed

        // For example, a method to retrieve a list of students by a specific criteria
        public List<Student> GetStudentsByCriteria(string criteria)
        {
            // Query the Students DbSet based on the criteria
            var matchingStudents = Students.Where(s => s.Name.Contains(criteria)).ToList();

            // Return the list of students that match the criteria
            return matchingStudents;
        }

        // For example, a method to retrieve a list of instructors by a specific criteria
        public List<Instructor> GetInstructorsByCriteria(string criteria)
        {
            // Query the Instructors DbSet based on the criteria
            var matchingInstructors = Instructors.Where(i => i.Name.Contains(criteria)).ToList();

            // Return the list of instructors that match the criteria
            return matchingInstructors;
        }

        public List<Course> GetCoursesByCriteria(string criteria)
        {
            // Query the Courses DbSet based on the criteria
            var matchingCourses = Courses.Where(c => c.Title.Contains(criteria)).ToList();

            // Return the list of courses that match the criteria
            return matchingCourses;
        }

    }
}
