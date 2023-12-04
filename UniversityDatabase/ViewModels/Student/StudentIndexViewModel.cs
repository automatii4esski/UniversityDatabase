namespace UniversityDatabase.ViewModels.Student
{
    using UniversityDatabase.Config;
    using UniversityDatabase.Models;
    public class StudentIndexViewModel
    {
        public List<Student> Students { get; set; } = new List<Student>();
    }
}
