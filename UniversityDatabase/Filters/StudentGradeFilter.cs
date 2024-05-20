using UniversityDatabase.Helpers;
using UniversityDatabase.Models;

namespace UniversityDatabase.Filters
{
    public class StudentGradeFilter
    {
        public int? StudyGroupId { get; set; }
        public List<byte?> GradeValueId { get; set; } = new();
        public int? SubjectId { get; set; }
        public byte? CourseId { get; set; }
        public byte? SemesterId { get; set; }

        public StudentGradeFilter() {
        }

        public IEnumerable<StudentGrade> GetFilteredStudentGrades(IEnumerable<StudentGrade> studentGrades)
        {
            studentGrades = StudyGroupId == null ? studentGrades : studentGrades.Where(s=>s.StudyPlan.StudyGroupId == StudyGroupId);
            studentGrades = GradeValueId.Count == 0 ? studentGrades : studentGrades.Where(s => GradeValueId.Any(g => g == s.GradeValueId));
            studentGrades = SubjectId == null ? studentGrades : studentGrades.Where(s => s.StudyPlan.SubjectId == SubjectId);
            studentGrades = CourseId == null ? studentGrades : studentGrades.Where(s => s.StudyPlan.CourseId == CourseId);
            studentGrades = SemesterId == null ? studentGrades : studentGrades.Where(s => s.StudyPlan.SemesterId == SemesterId);

            return studentGrades;
        }
    }
}
