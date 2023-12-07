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
            }
            _dbContext.SaveChanges();
        }

        public void CreateSubjects()
        {
            var subjects = new string[] { "Математика", "Русский", "Английский", "Физ-ра" };

            for (int i = 0; i < subjects.Length; i++)
            {
                var sex = _dbContext.Subjects.FirstOrDefault(s => s.Name == subjects[i]);

                if (sex != null) continue;

                _dbContext.Subjects.Add(new Subject { Name = subjects[i] });
            }
                _dbContext.SaveChanges();
        }

        public void CreateTypeOfOccupations()
        {
            var typeOfOccupations = new string[] { "Лекция", "Семинар", "Лабораторная работа", "Консультация", "Курсовая работа" };

            for (int i = 0; i < typeOfOccupations.Length; i++)
            {
                var typeOfOccupation = _dbContext.TypeOfOccupations.FirstOrDefault(t => t.Name == typeOfOccupations[i]);

                if (typeOfOccupation != null) continue;

                _dbContext.TypeOfOccupations.Add(new TypeOfOccupation { Name = typeOfOccupations[i] });
            }
                _dbContext.SaveChanges();
        }

        public void CreateFormOfControls()
        {
            var formOfControls = new string[] { "Зачет", "Экзамен"};

            for (int i = 0; i < formOfControls.Length; i++)
            {
                var formOfControl = _dbContext.FormOfControls.FirstOrDefault(f => f.Name == formOfControls[i]);

                if (formOfControl != null) continue;

                _dbContext.FormOfControls.Add(new FormOfControl { Name = formOfControls[i] });
            }
                _dbContext.SaveChanges();
        }

        public void CreateSexes()
        {
            var sexes = new string[]{ "Женский", "Мужской" };

            for (int i = 0; i < sexes.Length; i++)
            {
                var sex = _dbContext.Sexes.FirstOrDefault(s => s.Name == sexes[i]);

                if (sex != null) continue;

                _dbContext.Sexes.Add(new Sex { Name = sexes[i] });
            }
                _dbContext.SaveChanges();
        }

        public void CreateTeacherPositions()
        {
            var teacherPositions = new string[] { "Ассистент", "Преподаватель", "Старший преподаватель", "Преподаватель", "Доцент", "Профессор"  };

            for (int i = 0; i < teacherPositions.Length; i++)
            {
                var teacherPosition = _dbContext.TeacherPositions.FirstOrDefault(t => t.Name == teacherPositions[i]);

                if (teacherPosition != null) continue;

                _dbContext.TeacherPositions.Add(new TeacherPosition { Name = teacherPositions[i] });
            }
                _dbContext.SaveChanges();
        }

        public void CreateSemesters()
        {
            for (byte i = 1; i <= 2; i++)
            {
                var semester = _dbContext.Semesters.FirstOrDefault(c => c.Number == i);

                if (semester != null) continue;

                _dbContext.Semesters.Add(new Semester { Number = i });
            }
                _dbContext.SaveChanges();
        }
    }
}
