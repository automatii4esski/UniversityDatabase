namespace UniversityDatabase.ViewModels.Teacher
{
    using System.Reflection;
    using UniversityDatabase.Filters;
    using UniversityDatabase.Models;
    public class TeacherDetailsViewModel
    {
        public Teacher Teacher { get; set; } = new();
        public List<Workload> Workloads { get; set; } = new();
    }
}
