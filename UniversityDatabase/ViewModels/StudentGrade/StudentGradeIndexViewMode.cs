namespace UniversityDatabase.ViewModels.StudentGrade
{
    using UniversityDatabase.Filters;
    using UniversityDatabase.Models;
    public class StudentGradeIndexViewMode
    {
        public List<StudentGrade> StudentGrades { get; set; } = new();
        public StudentGradeFilter Filter { get; set; } = new();
        public Dictionary<int, string> StudyGroupOptions = new();
        public Dictionary<byte, string> GradeValueOptions = new();
        public Dictionary<int, string> SubjectOptions = new();
        public Dictionary<byte, byte> CourseOptions = new();
        public Dictionary<byte, byte> SemesterOptions = new();
    }
}
