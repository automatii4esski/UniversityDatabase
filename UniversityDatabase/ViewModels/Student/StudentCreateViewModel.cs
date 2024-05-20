namespace UniversityDatabase.ViewModels.Student
{
    using UniversityDatabase.Models;

    public class StudentCreateViewModel
    {
        public Student Student { get; set; } = new();
        public Dictionary<int, string> StudyGroupOptions { get; set; } = new();
        public Dictionary<byte, string> SexOptions { get; set; } = new();
        public IFormFile? Photo { get; set; }
    }
}
