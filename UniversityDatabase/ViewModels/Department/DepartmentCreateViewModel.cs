namespace UniversityDatabase.ViewModels.Department
{
    using UniversityDatabase.Models;

    public class DepartmentCreateViewModel
    {
        public Department Department { get; set; } = new();
        public Dictionary<int, string> FacultyOptions { get; set; } = new Dictionary<int, string>();
    }
}
