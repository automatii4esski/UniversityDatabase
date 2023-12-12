namespace UniversityDatabase.ViewModels.Workload
{
    using UniversityDatabase.Filters;
    using UniversityDatabase.Models;
    public class WorkloadIndexViewModel
    {
        public List<Workload> Workloads { get; set; } = new ();
        public Dictionary<int, string> StudyGroupOptions = new();
        public Dictionary<byte,byte> CourseOptions = new();
        public Dictionary<byte,byte> SemesterOptions = new();
        public Dictionary<int,string> TypeOfOccupationOptions = new();
        public WorkloadFilter Filter = new();
    }
}
