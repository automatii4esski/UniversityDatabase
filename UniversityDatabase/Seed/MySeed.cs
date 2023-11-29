using UniversityDatabase.Data;
using UniversityDatabase.Models;

namespace UniversityDatabase.Seed
{
    public class MySeed
    {
        private MyDbContext _dbContext;

        public MySeed(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCourses()
        {
            for (byte i = 1; i <= 4; i++)
            {
                var course = _dbContext.Courses.FirstOrDefault(c => c.Number == i);

                if (course != null) continue;

                _dbContext.Courses.Add(new Course { Number = i });
                _dbContext.SaveChanges();
            }
        }

        public void CreateSemesters()
        {
            for (byte i = 1; i <= 2; i++)
            {
                var semester = _dbContext.Semesters.FirstOrDefault(c => c.Number == i);

                if (semester != null) continue;

                _dbContext.Semesters.Add(new Semester { Number = i });
                _dbContext.SaveChanges();
            }
        }
    }
}
