using DataHUBWebApplication.Data.Interface;
using DataHUBWebApplication.Models;

    namespace DataHUBWebApplication.Data
    {
        public class DataRepository : IDataRepository
        {
            private readonly DataHUBWebApplicationContext _dbContext;

            public DataRepository(DataHUBWebApplicationContext dbContext)
            {
                _dbContext = dbContext;
            }

            public IEnumerable<Student> GetStudents()
            {
                var students = _dbContext.Students;

                // TODO: Perform any additional processing or filtering on the students if needed

                return students;
            }

            public IEnumerable<Instructor> GetInstructors()
            {
                var instructors = _dbContext.Instructors;

                // TODO: Perform any additional processing or filtering on the instructors if needed

                return instructors;
            }

            public IEnumerable<Course> GetCourses()
            {
                var courses = _dbContext.Courses;

                // TODO: Perform any additional processing or filtering on the courses if needed

                return courses;
            }
        }
    }
