namespace UniversityDatabase.ViewModels.Student
{
    using UniversityDatabase.Filters;
    using UniversityDatabase.Models;
    public class StudentDetailsViewModel
    {
        public Student Student { get; set; } = new();
        public List<StudentGrade> StudentGrades { get; set; } = new();
    }
}
