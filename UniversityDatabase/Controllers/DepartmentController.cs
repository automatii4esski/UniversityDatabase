using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using UniversityDatabase.Data;
using UniversityDatabase.Models;
using UniversityDatabase.ViewModels.Department;
using UniversityDatabase.ViewModels.Faculty;

namespace UniversityDatabase.Controllers
{
    public class DepartmentController : Controller
    {
        private MyDbContext _dbContext;

        public DepartmentController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var departmentList = _dbContext.Departments.ToList();

            var deprtmentViewModel = new DepartmentIndexViewModel { Departments = departmentList };

            return View(deprtmentViewModel);
        }

        public ActionResult Create()
        {
            var facultyOptions = _dbContext.Faculties.ToDictionary(d => d.Id, d => d.Name);
            var departmentViewModel = new DepartmentCreateViewModel { FacultyOptions = facultyOptions };

            return View(departmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            bool isFacultyExist = _dbContext.Faculties.Any(d => d.Id == department.FacultyId);

            if (!isFacultyExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Departments.Add(department);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var department = _dbContext.Departments.Find(id);

            var facultyOptions = _dbContext.Faculties.ToDictionary(d => d.Id, d => d.Name);


            if (department == null) return RedirectToAction(nameof(Index));

            var departmentViewModel = new DepartmentCreateViewModel { Department = department, FacultyOptions = facultyOptions };

            return View(departmentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            bool isFacultyExist = _dbContext.Faculties.Any(d => d.Id == department.FacultyId);

            if (!isFacultyExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Departments.Update(department);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var department = _dbContext.Departments.Find(id);

            if (department == null) return RedirectToAction(nameof(Index));

            _dbContext.Departments.Remove(department);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
