
namespace UniversityDatabase.ViewModels.StudyGroup
{
using UniversityDatabase.Models;
    public class StudyGroupCreateViewModel
    {
        public StudyGroup StudyGroup { get; set; } = new ();
        public Dictionary<byte, byte> CourseOptions = new Dictionary<byte, byte>();
        public Dictionary<int, string> FacultyOptions = new Dictionary<int, string>();
    }
}
