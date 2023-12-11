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
            
            bool isDepartmentExist = _dbContext.Departments.Any(s => s.Id == teacher.DepartmentId);
            bool isSexExist = _dbContext.Sexes.Any(s => s.Id == teacher.SexId);
            bool isTeacherPositionExist = _dbContext.TeacherPositions.Any(s => s.Id == teacher.TeacherPositionId);

            if (!isDepartmentExist || !isSexExist || !isTeacherPositionExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Teachers.Add(teacher);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var teacher = _dbContext.Teachers.Find(id);

            if (teacher == null) return RedirectToAction(nameof(Index));

            var departmentOptions = _dbContext.Departments.ToDictionary(s => s.Id, s => s.Name);
            var sexOptions = _dbContext.Sexes.ToDictionary(s => s.Id, s => s.Name);
            var teacherPositionOptions = _dbContext.TeacherPositions.ToDictionary(s => s.Id, s => s.Name);

            var teacherViewModel = new TeacherCreateViewModel { 
                Teacher = teacher, 
                TeacherPositionOptions = teacherPositionOptions, 
                SexOptions = sexOptions, 
                DepartmentOptions = departmentOptions };

            return View(teacherViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Teacher teacher)
        {
            bool isDepartmentExist = _dbContext.Departments.Any(s => s.Id == teacher.DepartmentId);
            bool isSexExist = _dbContext.Sexes.Any(s => s.Id == teacher.SexId);
            bool isTeacherPositionExist = _dbContext.TeacherPositions.Any(s => s.Id == teacher.TeacherPositionId);

            if (!isDepartmentExist || !isSexExist || !isTeacherPositionExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Teachers.Update(teacher);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var teacher = _dbContext.Teachers.Find(id);

            if (teacher == null) return RedirectToAction(nameof(Index));

            _dbContext.Teachers.Remove(teacher);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
