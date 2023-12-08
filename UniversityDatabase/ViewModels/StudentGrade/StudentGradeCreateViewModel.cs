namespace UniversityDatabase.ViewModels.StudentGrade
{
    using UniversityDatabase.Models;
    public class StudentGradeCreateViewMode
    {
        public StudentGrade StudentGrade { get; set; } = new();
        public Dictionary<byte, string> GradeValueOptions = new();
    }
}
