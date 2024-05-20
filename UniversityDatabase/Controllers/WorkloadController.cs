using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using UniversityDatabase.Data;
using UniversityDatabase.Filters;
using UniversityDatabase.Models;
using UniversityDatabase.Seed;
using UniversityDatabase.ViewModels.Student;
using UniversityDatabase.ViewModels.Teacher;
using UniversityDatabase.ViewModels.Workload;

namespace UniversityDatabase.Controllers
{
    public class WorkloadController : Controller
    {
        private MyDbContext _dbContext;

        public WorkloadController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private WorkloadIndexViewModel GetIndexViewModelWithOptions()
        {
            var StudyGroupOptions = _dbContext.StudyGroups.ToDictionary(s => s.Id, s => s.Name);
            var CourseOptions = _dbContext.Courses.ToDictionary(s => s.Id, s => s.Number);
            var SemesterOptions = _dbContext.Semesters.ToDictionary(s => s.Id, s => s.Number);
            var typeOfOccupationOptions = _dbContext.TypeOfOccupations.ToDictionary(s => s.Id, s => s.Name);

            var workloadViewModel = new WorkloadIndexViewModel
            {
                StudyGroupOptions = StudyGroupOptions,
                CourseOptions = CourseOptions,
                SemesterOptions = SemesterOptions,
                TypeOfOccupationOptions = typeOfOccupationOptions
            };

            return workloadViewModel;
        }

        public ActionResult Index()
        {
            var workloadList = _dbContext.Workloads.Select(w =>
            new Workload
            {
                Id = w.Id,
                Teacher = new Teacher {Name= w.Teacher.Name, Surname= w.Teacher.Surname, Patronymic = w.Teacher.Patronymic },
                TotalHours = w.TotalHours,
                StudyPlan = new StudyPlan { Course = new Course {Number = w.StudyPlan.Course.Number }, 
                    Semester = new Semester { Number = w.StudyPlan.Semester.Number},
                    Subject = new Subject { Name = w.StudyPlan.Subject.Name},
                    TypeOfOccupation = new TypeOfOccupation { Name = w.StudyPlan.TypeOfOccupation.Name },
                    FormOfControl = new FormOfControl { Name = w.StudyPlan.FormOfControl.Name },
                    StudyGroup = new StudyGroup { Name = w.StudyPlan.StudyGroup.Name },
                }

            }).ToList();

            var workloadViewModel = GetIndexViewModelWithOptions();
            workloadViewModel.Workloads = workloadList;

            return View(workloadViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(byte? courseId, byte? semesterId, int? studyGroupId, int? typeOfOccupationId)
        {
            var workloadList = _dbContext.Workloads.Select(w =>
            new Workload
            {
                Id = w.Id,
                Teacher = new Teacher { Name = w.Teacher.Name, Surname = w.Teacher.Surname, Patronymic = w.Teacher.Patronymic },
                TotalHours = w.TotalHours,
                StudyPlan = new StudyPlan
                {
                    Course = new Course { Number = w.StudyPlan.Course.Number },
                    CourseId = w.StudyPlan.CourseId,
                    SemesterId = w.StudyPlan.SemesterId,
                    StudyGroupId = w.StudyPlan.StudyGroupId,
                    TypeOfOccupationId = w.StudyPlan.TypeOfOccupationId,
                    Semester = new Semester { Number = w.StudyPlan.Semester.Number },
                    Subject = new Subject { Name = w.StudyPlan.Subject.Name },
                    TypeOfOccupation = new TypeOfOccupation { Name = w.StudyPlan.TypeOfOccupation.Name },
                    FormOfControl = new FormOfControl { Name = w.StudyPlan.FormOfControl.Name },
                    StudyGroup = new StudyGroup { Name = w.StudyPlan.StudyGroup.Name },
                }

            }).AsEnumerable();

            var filter = new WorkloadFilter { CourseId = courseId, SemesterId = semesterId, StudyGroupId = studyGroupId, TypeOfOccupationId= typeOfOccupationId };
            var workloadViewModel = GetIndexViewModelWithOptions();
            workloadViewModel.Workloads = filter.GetFilteredWorkloads(workloadList).ToList();
            workloadViewModel.Filter = filter;

            return View(workloadViewModel);
        }

        public ActionResult Create(int studyPlanId, int teacherId)
        {
            var teacherWithThisStudyPlan = _dbContext.Workloads.FirstOrDefault(w=> w.TeacherId == teacherId && w.StudyPlanId == studyPlanId);

            if (teacherWithThisStudyPlan != null)
            {
                return RedirectToAction(nameof(Edit), new {id = teacherWithThisStudyPlan.Id});
            }

            var studyPlan = _dbContext.StudyPlans.Select(s => new StudyPlan
            {
                Id = s.Id,
                TotalHours = s.TotalHours,
                RemainingHours = s.RemainingHours,
                Course = new Course { Number = s.Course.Number },
                Semester = new Semester { Number = s.Semester.Number },
                Subject = new Subject { Name = s.Subject.Name },
                StudyGroup = new StudyGroup { Name = s.StudyGroup.Name },
                FormOfControl = new FormOfControl { Name = s.FormOfControl.Name },
                TypeOfOccupation = new TypeOfOccupation { Name = s.TypeOfOccupation.Name }
            }).FirstOrDefault(s => s.Id == studyPlanId);

            var teacher = _dbContext.Teachers.Select(t => new Teacher
            {
                Id = t.Id,
                Name= t.Name,
                Surname = t.Surname,
                Department = t.Department,
                DateOfBirth = t.DateOfBirth,
                Sex = t.Sex,
                PhotoUrl = t.PhotoUrl
            }).FirstOrDefault(t => t.Id == teacherId);

            if(teacher == null || studyPlan == null)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            var workload = new Workload { StudyPlanId = studyPlanId, TeacherId = teacherId, StudyPlan = studyPlan, Teacher = teacher };
            var otherWorkloadList = GetOtherWorkloadsOfStudyPlan(studyPlan.Id);
            var workloadViewModel = new WorkloadCreateViewModel { OtherWorkloads = otherWorkloadList, Workload = workload };

            return View(workloadViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workload workload)
        {
            try
            {
                var studyPlan = _dbContext.StudyPlans.First(s => s.Id == workload.StudyPlanId);

                studyPlan.RemainingHours -= workload.TotalHours;

                if (studyPlan.RemainingHours < 0) throw new Exception("No remaining hours");

                _dbContext.StudyPlans.Update(studyPlan);
                _dbContext.Workloads.Add(workload);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        private List<Workload> GetOtherWorkloadsOfStudyPlan(int studyPlanId)
        {
            var workloadList = _dbContext.Workloads.Where(w => w.StudyPlanId == studyPlanId)
                .Select(w => new Workload
                {
                    Id = w.Id,
                    TotalHours = w.TotalHours,
                    Teacher = new Teacher
                    {
                        Name = w.Teacher.Name,
                        Surname = w.Teacher.Surname,
                        Patronymic = w.Teacher.Patronymic
                    }
                }).ToList();

            return workloadList;
        }

        public ActionResult Edit(int id, string? backUrl)
        {
            try
            {
                var workload = _dbContext.Workloads.First(w => w.Id == id);

                var studyPlan = _dbContext.StudyPlans.Select(s => new StudyPlan
                {
                    Id = s.Id,
                    TotalHours = s.TotalHours,
                    RemainingHours = s.RemainingHours,
                    Course = new Course { Number = s.Course.Number },
                    Semester = new Semester { Number = s.Semester.Number },
                    Subject = new Subject { Name = s.Subject.Name },
                    StudyGroup = new StudyGroup { Name = s.StudyGroup.Name },
                    FormOfControl = new FormOfControl { Name = s.FormOfControl.Name },
                    TypeOfOccupation = new TypeOfOccupation { Name = s.TypeOfOccupation.Name }
                }).FirstOrDefault(s => s.Id == workload.StudyPlanId);

                var teacher = _dbContext.Teachers.Select(t => new Teacher
                {
                    Id = t.Id,
                    Name = t.Name,
                    Surname = t.Surname,
                    Patronymic = t.Patronymic,
                    Department = t.Department,
                    DateOfBirth = t.DateOfBirth,
                    Sex = t.Sex,
                    PhotoUrl = t.PhotoUrl
                }).FirstOrDefault(t => t.Id == workload.TeacherId);

                if (studyPlan == null || teacher == null) throw new Exception("No studyplan or teacher");

                workload.Teacher = teacher;
                workload.StudyPlan = studyPlan;
                var otherWorkloadList = GetOtherWorkloadsOfStudyPlan(studyPlan.Id);

                var workloadViewModel = new WorkloadCreateViewModel { BackUrl = backUrl, OtherWorkloads = otherWorkloadList, Workload = workload };

                return View(workloadViewModel);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Workload workload, int initialTotalHours, string? backUrl)
        {
            try
            {
                var studyPlan = _dbContext.StudyPlans.First( s=> s.Id == workload.StudyPlanId);

                var totalHoursDiff = initialTotalHours - workload.TotalHours;
                studyPlan.RemainingHours += totalHoursDiff;

                if (studyPlan.RemainingHours < 0) throw new Exception("No remaining hours");

                _dbContext.Workloads.Update(workload);
                _dbContext.StudyPlans.Update(studyPlan);
                _dbContext.SaveChanges();

                return backUrl == null ? RedirectToAction(nameof(Index)) : Redirect(backUrl);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, string? backUrl)
        {

            try
            {
                var workload = _dbContext.Workloads.First(w => w.Id == id);

                var studyPlan = _dbContext.StudyPlans.First( s=> s.Id == workload.StudyPlanId);

                studyPlan.RemainingHours += workload.TotalHours;

                _dbContext.Workloads.Remove(workload);
                _dbContext.StudyPlans.Update(studyPlan);
                _dbContext.SaveChanges();

                var previusUrl = Request.Headers["Referer"].ToString();

                return backUrl == null ? RedirectToAction(nameof(Index)) : Redirect(backUrl);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
