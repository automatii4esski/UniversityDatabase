using UniversityDatabase.Config;
using UniversityDatabase.Models;

namespace UniversityDatabase.Filters
{
    public class TeacherFilter
    {
        public int? DepartmentId { get; set; }
        public byte? SexId { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public int? MaxSalary { get; set; }
        public int? MinSalary { get; set; }
        public int? TeacherPositionId { get; set; }

        public TeacherFilter() {
        }

        public IEnumerable<Teacher> GetFilteredTeachers(IEnumerable<Teacher> teachers)
        {
            teachers = DepartmentId == null ? teachers : teachers.Where(s=>s.DepartmentId == DepartmentId);
            teachers = SexId == null ? teachers : teachers.Where(s=>s.SexId == SexId);
            teachers = TeacherPositionId == null ? teachers : teachers.Where(s => s.TeacherPositionId == TeacherPositionId);
            teachers = MinSalary == null ? teachers : teachers.Where(s => s.Salary >= MinSalary);
            teachers = MaxSalary == null ? teachers : teachers.Where(s => s.Salary <= MaxSalary);
            teachers = MaxAge == null ? teachers : teachers.Where(s => MyDate.GetAge(s.DateOfBirth) <= MaxAge);
            teachers = MinAge == null ? teachers : teachers.Where(s => MyDate.GetAge(s.DateOfBirth) >= MinAge);

            return teachers;
        }
    }
}
