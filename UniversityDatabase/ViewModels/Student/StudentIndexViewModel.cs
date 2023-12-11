namespace UniversityDatabase.ViewModels.Student
{
    using UniversityDatabase.Filters;
    using UniversityDatabase.Models;
    public class StudentIndexViewModel
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public StudentFilter Filter { get; set; } = new();
        public Dictionary<int, string> StudyGroupOptions = new();
        public Dictionary<byte, string> SexOptions = new();
        public Dictionary<byte, byte> CourseOptions = new();
        public Dictionary<int, string> FacultyOptions = new();
    }
}
