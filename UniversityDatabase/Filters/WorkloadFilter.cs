using UniversityDatabase.Config;
using UniversityDatabase.Models;

namespace UniversityDatabase.Filters
{
    public class WorkloadFilter
    {
        public int? StudyGroupId { get; set; }
        public byte? CourseId { get; set; }
        public byte? SemesterId { get; set; }
        public int? TypeOfOccupationId { get; set; }

        public WorkloadFilter() {
        }

        public IEnumerable<Workload> GetFilteredWorkloads(IEnumerable<Workload> workloads)
        {
            workloads = StudyGroupId == null ? workloads : workloads.Where(s=>s.StudyPlan.StudyGroupId == StudyGroupId);
            workloads = CourseId == null ? workloads : workloads.Where(s => s.StudyPlan.CourseId == CourseId);
            workloads = SemesterId == null ? workloads : workloads.Where(s => s.StudyPlan.SemesterId == SemesterId);
            workloads = TypeOfOccupationId == null ? workloads : workloads.Where(s => s.StudyPlan.TypeOfOccupationId == TypeOfOccupationId);

            return workloads;
        }
    }
}
