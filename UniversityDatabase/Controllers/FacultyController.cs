using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityDatabase.Data;
using UniversityDatabase.Models;
using UniversityDatabase.ViewModels.Faculty;

namespace UniversityDatabase.Controllers
{
    public class FacultyController : Controller
    {
        private MyDbContext _dbContext;

        public FacultyController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var facultyList = _dbContext.Faculties.ToList();

            var facultyViewModel = new FacultyIndexViewModel { Faculties = facultyList };

            return View(facultyViewModel);
        }

        public ActionResult Create()
        {
            var densOptions = _dbContext.Deans.ToDictionary(d => d.Id, d => d.Name);
            var facultyViewModel = new FacultyCreateViewModel { DeansOptions = densOptions };

            return View(facultyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Faculty faculty)
        {
            bool isDeanExist = _dbContext.Deans.Any(d => d.Id == faculty.DeanId);

            if (!isDeanExist) {
                TempData["error"] = "error test";
              return  RedirectToAction(nameof(Index));
            } 

            _dbContext.Faculties.Add(faculty);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
           var faculty = _dbContext.Faculties.Find(id);

            var densOptions = _dbContext.Deans.ToDictionary(d => d.Id, d => d.Name);


            if (faculty == null)return RedirectToAction(nameof(Index));

            var facultyViewModel = new FacultyCreateViewModel { Faculty = faculty, DeansOptions = densOptions };

            return View(facultyViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faculty faculty)
        {
            bool isDeanExist = _dbContext.Deans.Any(d => d.Id == faculty.DeanId);

            if (!isDeanExist) {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Faculties.Update(faculty);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var faculty = _dbContext.Faculties.Find(id);

            if (faculty == null) return RedirectToAction(nameof(Index));

            _dbContext.Faculties.Remove(faculty);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
