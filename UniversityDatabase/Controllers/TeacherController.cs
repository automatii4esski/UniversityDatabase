using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using UniversityDatabase.Data;
using UniversityDatabase.Filters;
using UniversityDatabase.Models;
using UniversityDatabase.Seed;
using UniversityDatabase.ViewModels.Student;
using UniversityDatabase.ViewModels.Teacher;

namespace UniversityDatabase.Controllers
{
    public class TeacherController : Controller
    {
        private MyDbContext _dbContext;

        public TeacherController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private TeacherIndexViewModel GetIndexViewModelWithOptions()
        {
            var departmentOptions = _dbContext.Departments.ToDictionary(s => s.Id, s => s.Name);
            var sexOptions = _dbContext.Sexes.ToDictionary(s => s.Id, s => s.Name);
            var teacherPositionOptions = _dbContext.TeacherPositions.ToDictionary(s => s.Id, s => s.Name);

            var teacherViewModel = new TeacherIndexViewModel {DepartmentOptions = departmentOptions, SexOptions = sexOptions, TeacherPositionOptions =teacherPositionOptions  };

            return teacherViewModel;
        }

        public ActionResult Index(int? studyPlanId)
        {
            var teacherList = _dbContext.Teachers.Select(t =>
            new Teacher
            {
                Id = t.Id,
                Name = t.Name,
                Surname =t.Surname,
                Patronymic =t.Patronymic,
                Sex = new Sex { Name = t.Sex.Name },
                Salary = t.Salary,
                TeacherPosition = new TeacherPosition { Name = t.TeacherPosition.Name },
                Department = new Department { Name = t.Department.Name },
                DateOfBirth = t.DateOfBirth,
            }).ToList();

            var teacherViewModel = GetIndexViewModelWithOptions();

            teacherViewModel.Teachers = teacherList;
            teacherViewModel.StudyPlanIdForWorkload = studyPlanId;

            return View(teacherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? studyPlanId, int? departmentId, byte? sexId, int? minAge, int? maxAge, int? maxSalary, int? minSalary, int? teacherPositionId)
        {
            var teacherList = _dbContext.Teachers.Select(t =>
            new Teacher
            {
                Id = t.Id,
                Name = t.Name,
                Surname = t.Surname,
                Patronymic = t.Patronymic,
                Sex = new Sex { Name = t.Sex.Name },
                Salary = t.Salary,
                TeacherPosition = new TeacherPosition { Name = t.TeacherPosition.Name },
                TeacherPositionId = t.TeacherPositionId,
                DepartmentId = t.DepartmentId,
                SexId = t.SexId,
                Department = new Department { Name = t.Department.Name },
                DateOfBirth = t.DateOfBirth,
            }).AsEnumerable();

            var teacherViewModel = GetIndexViewModelWithOptions();
            var filter = new TeacherFilter { DepartmentId = departmentId, SexId = sexId, TeacherPositionId = teacherPositionId, MaxAge = maxAge, MinAge = minAge, MaxSalary = maxSalary, MinSalary = minSalary };

            teacherViewModel.Teachers = filter.GetFilteredTeachers(teacherList).ToList();
            teacherViewModel.StudyPlanIdForWorkload = studyPlanId;
            teacherViewModel.Filter = filter;

            return View(teacherViewModel);
        }

        public ActionResult Details(int id)
        {
            
            try
            {
                var teacher = _dbContext.Teachers.Select(t =>
            new Teacher
            {
                Id = t.Id,
                Name = t.Name,
                Surname = t.Surname,
                Patronymic = t.Patronymic,
                Sex = new Sex { Name = t.Sex.Name },
                Salary = t.Salary,
                TeacherPosition = new TeacherPosition { Name = t.TeacherPosition.Name },
                Department = new Department { Name = t.Department.Name },
                DateOfBirth = t.DateOfBirth,
            }).FirstOrDefault(t => t.Id == id);

                if (teacher == null) throw new Exception("No teacher found");

                var workloads = _dbContext.Workloads.Where(w => w.TeacherId == id).Select(w => new Workload
                {
                    Id = w.Id,
                    TotalHours = w.TotalHours,
                    StudyPlan = new StudyPlan
                    {
                        Course = new Course { Number = w.StudyPlan.Course.Number },
                        Semester = new Semester { Number = w.StudyPlan.Semester.Number },
                        Subject = new Subject { Name = w.StudyPlan.Subject.Name },
                        TypeOfOccupation = new TypeOfOccupation { Name = w.StudyPlan.TypeOfOccupation.Name },
                        FormOfControl = new FormOfControl { Name = w.StudyPlan.FormOfControl.Name },
                        StudyGroup = new StudyGroup { Name = w.StudyPlan.StudyGroup.Name },
                    }
                }).ToList();

                var viewModel = new TeacherDetailsViewModel { Teacher = teacher, Workloads = workloads };

                return View(viewModel);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }


        public ActionResult Create()
        {
            var departmentOptions = _dbContext.Departments.ToDictionary(s => s.Id, s => s.Name);
            var sexOptions  = _dbContext.Sexes.ToDictionary(s => s.Id, s => s.Name);
            var teacherPositionOptions  = _dbContext.TeacherPositions.ToDictionary(s => s.Id, s => s.Name);

            var teacherViewModel = new TeacherCreateViewModel { 
                TeacherPositionOptions = teacherPositionOptions,
                SexOptions = sexOptions,  
                DepartmentOptions = departmentOptions };

            return View(teacherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher)
        {
            try
            {
                _dbContext.Teachers.Add(teacher);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult Edit(int id)
        {
            
            try
            {
                var teacher = _dbContext.Teachers.First(t => t.Id == id);

                var departmentOptions = _dbContext.Departments.ToDictionary(s => s.Id, s => s.Name);
                var sexOptions = _dbContext.Sexes.ToDictionary(s => s.Id, s => s.Name);
                var teacherPositionOptions = _dbContext.TeacherPositions.ToDictionary(s => s.Id, s => s.Name);

                var teacherViewModel = new TeacherCreateViewModel
                {
                    Teacher = teacher,
                    TeacherPositionOptions = teacherPositionOptions,
                    SexOptions = sexOptions,
                    DepartmentOptions = departmentOptions
                };

                return View(teacherViewModel);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher teacher)
        {
            try
            {
                _dbContext.Teachers.Update(teacher);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var teacher = _dbContext.Teachers.First(t => t.Id == id);

                _dbContext.Teachers.Remove(teacher);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            } 
            
        }
    }
}
