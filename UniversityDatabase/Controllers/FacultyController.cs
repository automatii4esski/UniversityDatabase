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
            try
            {
                _dbContext.Faculties.Add(faculty);
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
                var faculty = _dbContext.Faculties.First(f=> f.Id == id);

                var densOptions = _dbContext.Deans.ToDictionary(d => d.Id, d => d.Name);

                var facultyViewModel = new FacultyCreateViewModel { Faculty = faculty, DeansOptions = densOptions };

                return View(facultyViewModel);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Faculty faculty)
        {
            
            try
            {
                _dbContext.Faculties.Update(faculty);
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
                var faculty = _dbContext.Faculties.First(f=> f.Id==id);

                _dbContext.Faculties.Remove(faculty);
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
