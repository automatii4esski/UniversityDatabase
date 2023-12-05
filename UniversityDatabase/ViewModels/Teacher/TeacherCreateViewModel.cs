namespace UniversityDatabase.ViewModels.Teacher
{
    using UniversityDatabase.Models;

    public class TeacherCreateViewModel
    {
        public Teacher Teacher { get; set; } = new();
        public Dictionary<int, string> DepartmentOptions { get; set; } = new();
        public Dictionary<byte, string> SexOptions { get; set; } = new();
        public Dictionary<byte, string> TeacherPositionOptions { get; set; } = new();
    }
}
