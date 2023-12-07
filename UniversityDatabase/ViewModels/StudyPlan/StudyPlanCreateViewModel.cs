namespace UniversityDatabase.ViewModels.StudyPlan
{
    using UniversityDatabase.Models;
    public class StudyPlanCreateViewModel
    {
        public StudyPlan StudyPlan { get; set; } = new();
        public Dictionary<byte, byte> CourseOptions { get; set; } = new();
        public Dictionary<byte, byte> SemesterOptions { get; set; } = new();
        public Dictionary<int, string> SubjectOptions { get; set; } = new();
        public Dictionary<int, string> StudyGroupOptions { get; set; } = new();
        public Dictionary<int, string> FormOfControlOptions { get; set; } = new();
        public Dictionary<int, string> TypeOfOccupationOptions { get; set; } = new();
    }
}
