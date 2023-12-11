namespace UniversityDatabase.ViewModels.Teacher
{
    using System.Reflection;
    using UniversityDatabase.Filters;
    using UniversityDatabase.Models;
    public class TeacherIndexViewModel
    {
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public int? StudyPlanIdForWorkload { get; set; }
        public Dictionary<int, string> DepartmentOptions = new();
        public Dictionary<byte, string> SexOptions = new();
        public Dictionary<byte, string> TeacherPositionOptions = new();
        public TeacherFilter Filter { get; set; } = new();
    }
}
