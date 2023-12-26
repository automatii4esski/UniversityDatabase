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

            var departmentList = _dbContext.Departments.Select(d =>
            new Department
            {
                Id = d.Id,
                Name = d.Name,
                Phone = d.Phone,
                Faculty = new Faculty { Name = d.Faculty.Name, Dean = new Dean { Name = d.Faculty.Dean.Name } },
            }).ToList();

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
            try
            {
                _dbContext.Departments.Add(department);
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
                var department = _dbContext.Departments.First(d => d.Id == id);

                var facultyOptions = _dbContext.Faculties.ToDictionary(d => d.Id, d => d.Name);

                var departmentViewModel = new DepartmentCreateViewModel { Department = department, FacultyOptions = facultyOptions };

                return View(departmentViewModel);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            
            try
            {
                _dbContext.Departments.Update(department);
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
                var department = _dbContext.Departments.First(d=> d.Id==id);

                _dbContext.Departments.Remove(department);
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
