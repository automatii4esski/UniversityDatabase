namespace UniversityDatabase.ViewModels.Teacher
{
    using UniversityDatabase.Models;
    public class TeacherIndexViewModel
    {
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
        public int? StudyPlanIdForWorkload { get; set; }
    }
}
