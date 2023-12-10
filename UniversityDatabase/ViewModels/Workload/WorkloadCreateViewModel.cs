namespace UniversityDatabase.ViewModels.Workload
{
    using UniversityDatabase.Models;

    public class WorkloadCreateViewModel
    {
        public Workload Workload { get; set; } = new();
        public List<Workload> OtherWorkloads = new();
    }
}
