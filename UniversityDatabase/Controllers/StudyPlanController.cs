using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityDatabase.Data;
using UniversityDatabase.Models;
using UniversityDatabase.Seed;
using UniversityDatabase.ViewModels.Department;
using UniversityDatabase.ViewModels.StudyGroup;
using UniversityDatabase.ViewModels.StudyPlan;

namespace UniversityDatabase.Controllers
{
    public class StudyPlanController : Controller
    {

        private MyDbContext _dbContext;

        public StudyPlanController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var studyPlanList = _dbContext.StudyPlans.Select(s =>
            new StudyPlan
            {
                Id = s.Id,
                TotalHours = s.TotalHours,
                Course = new Course { Number = s.Course.Number },
                Semester = new Semester { Number = s.Semester.Number },
                Subject = new Subject { Name = s.Subject.Name },
                StudyGroup = new StudyGroup { Name = s.StudyGroup.Name },
                FormOfControl = new FormOfControl { Name = s.FormOfControl.Name },
                TypeOfOccupation = new TypeOfOccupation { Name = s.TypeOfOccupation.Name },
            }).ToList();


            var studyPlanViewModel = new StudyPlanIndexViewModel { StudyPlans = studyPlanList };

            return View(studyPlanViewModel);
        }


        public ActionResult Create()
        {
            var semesterOptions = _dbContext.Semesters.ToDictionary(d => d.Id, d => d.Number);
            var coursesOptions = _dbContext.Courses.ToDictionary(d => d.Id, d => d.Number);
            var subjectOptions = _dbContext.Subjects.ToDictionary(d => d.Id, d => d.Name);
            var studyGroupOptions = _dbContext.StudyGroups.ToDictionary(d => d.Id, d => d.Name);
            var formOfControlOptions = _dbContext.FormOfControls.ToDictionary(d => d.Id, d => d.Name);
            var typeOfOccupationOptions = _dbContext.TypeOfOccupations.ToDictionary(d => d.Id, d => d.Name);

            var studyPlanViewModel = new StudyPlanCreateViewModel { 
                SemesterOptions = semesterOptions, 
                CourseOptions = coursesOptions,
                SubjectOptions = subjectOptions,
                StudyGroupOptions = studyGroupOptions,
                FormOfControlOptions = formOfControlOptions,
                TypeOfOccupationOptions = typeOfOccupationOptions
            };


            return View(studyPlanViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudyPlan studyPlan)
        {
           
            bool isCourseExist = _dbContext.Courses.Any(c => c.Id == studyPlan.CourseId);
            bool isSemesterExist = _dbContext.Semesters.Any(c => c.Id == studyPlan.SemesterId);
            bool isSubjectExist = _dbContext.Subjects.Any(c => c.Id == studyPlan.SubjectId);
            bool isStudyGroupExist = _dbContext.StudyGroups.Any(c => c.Id == studyPlan.StudyGroupId);
            bool isFormOfControlExist = _dbContext.FormOfControls.Any(c => c.Id == studyPlan.FormOfControlId);
            bool isTypeOfOccupationExist = _dbContext.TypeOfOccupations.Any(c => c.Id == studyPlan.TypeOfOccupationId);

            if ( !isCourseExist || !isSemesterExist || !isSubjectExist || !isStudyGroupExist || !isFormOfControlExist || !isTypeOfOccupationExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.StudyPlans.Add(studyPlan);

            _dbContext.SaveChanges();

            var studentsOfStudyGroup = _dbContext.Students.Where(s => s.StudyGroupId == studyPlan.StudyGroupId).ToList();
            foreach (var student in studentsOfStudyGroup)
            {
                _dbContext.StudentGrades.Add(new StudentGrade { StudentId = student.Id, StudyPlanId = studyPlan.Id });
            }

            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var studyPlan = _dbContext.StudyPlans.Find(id);

            if (studyPlan == null) return RedirectToAction(nameof(Index));

            var semesterOptions = _dbContext.Semesters.ToDictionary(d => d.Id, d => d.Number);
            var coursesOptions = _dbContext.Courses.ToDictionary(d => d.Id, d => d.Number);
            var subjectOptions = _dbContext.Subjects.ToDictionary(d => d.Id, d => d.Name);
            var studyGroupOptions = _dbContext.StudyGroups.ToDictionary(d => d.Id, d => d.Name);
            var formOfControlOptions = _dbContext.FormOfControls.ToDictionary(d => d.Id, d => d.Name);
            var typeOfOccupationOptions = _dbContext.TypeOfOccupations.ToDictionary(d => d.Id, d => d.Name);

            var studyPlanViewModel = new StudyPlanCreateViewModel
            {
                StudyPlan = studyPlan,
                SemesterOptions = semesterOptions,
                CourseOptions = coursesOptions,
                SubjectOptions = subjectOptions,
                StudyGroupOptions = studyGroupOptions,
                FormOfControlOptions = formOfControlOptions,
                TypeOfOccupationOptions = typeOfOccupationOptions
            };

            return View(studyPlanViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudyPlan studyPlan)
        {
            bool isCourseExist = _dbContext.Courses.Any(c => c.Id == studyPlan.CourseId);
            bool isSemesterExist = _dbContext.Semesters.Any(c => c.Id == studyPlan.SemesterId);
            bool isSubjectExist = _dbContext.Subjects.Any(c => c.Id == studyPlan.SubjectId);
            bool isStudyGroupExist = _dbContext.StudyGroups.Any(c => c.Id == studyPlan.StudyGroupId);
            bool isFormOfControlExist = _dbContext.FormOfControls.Any(c => c.Id == studyPlan.FormOfControlId);
            bool isTypeOfOccupationExist = _dbContext.TypeOfOccupations.Any(c => c.Id == studyPlan.TypeOfOccupationId);

            if (!isCourseExist || !isSemesterExist || !isSubjectExist || !isStudyGroupExist || !isFormOfControlExist || !isTypeOfOccupationExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.StudyPlans.Update(studyPlan);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var studyPlan = _dbContext.StudyPlans.Find(id);

            if (studyPlan == null) return RedirectToAction(nameof(Index));

            _dbContext.StudyPlans.Remove(studyPlan);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
