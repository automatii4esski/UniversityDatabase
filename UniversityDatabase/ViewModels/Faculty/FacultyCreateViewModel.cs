
namespace UniversityDatabase.ViewModels.Faculty
{
    using UniversityDatabase.Models;

    public class FacultyCreateViewModel
    {
        public Faculty Faculty { get; set; } = new();
        public Dictionary<int, string> DeansOptions { get; set; } = new Dictionary<int, string>();
    }
}
