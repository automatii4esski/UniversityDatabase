using UniversityDatabase.Helpers;
using UniversityDatabase.Models;

namespace UniversityDatabase.Filters
{
    public class StudentFilter
    {
        public int? StudyGroupId { get; set; }
        public byte? SexId { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public byte? CourseId { get; set; }
        public int? FacultyId { get; set; }

        public StudentFilter() {
        }

        public IEnumerable<Student> GetFilteredStudents(IEnumerable<Student> students)
        {
            students = StudyGroupId == null ? students : students.Where(s=>s.StudyGroupId == StudyGroupId);
            students = SexId == null ? students : students.Where(s=>s.SexId == SexId);
            students = MinAge == null ?
                students :
                students.Where(s => MyDate.GetAge(s.DateOfBirth) >= MinAge );
            students = MaxAge == null ? students : students.Where(s => MyDate.GetAge(s.DateOfBirth) <= MaxAge);
            students = CourseId == null ? students : students.Where(s => s.StudyGroup.CourseId == CourseId);
            students = FacultyId == null ? students : students.Where(s => s.StudyGroup.FacultyId == FacultyId);

            return students;
        }

        public StudentFilter SetFilters(StudentFilter? filter)
        {
            if (filter != null)
            {
                StudyGroupId = filter.StudyGroupId;
                SexId = filter.SexId;
                MinAge = filter.MinAge;
                MaxAge = filter.MaxAge;
            }
            

            return this;
        }
    }
}
