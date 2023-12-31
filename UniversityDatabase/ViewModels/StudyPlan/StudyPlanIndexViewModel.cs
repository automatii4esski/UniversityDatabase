﻿namespace UniversityDatabase.ViewModels.StudyPlan
{
    using UniversityDatabase.Models;
    public class StudyPlanIndexViewModel
    {
        public List<StudyPlan> StudyPlans { get; set; } = new ();
        public bool IsRenderForWorkload { get; set; } = false;
    }
}
