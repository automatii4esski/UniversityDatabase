using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityDatabase.Data;
using UniversityDatabase.Models;
using UniversityDatabase.ViewModels.Department;
using UniversityDatabase.ViewModels.StudyGroup;

namespace UniversityDatabase.Controllers
{
    public class StudyGroupController : Controller
    {

        private MyDbContext _dbContext;

        public StudyGroupController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {

            var studyGroupList = _dbContext.StudyGroups.Select(s =>
            new StudyGroup
            {
                Id = s.Id,
                Name = s.Name,
                RecruitmentYear = s.RecruitmentYear,
                Faculty = new Faculty { Name = s.Faculty.Name, Dean = s.Faculty.Dean },
                Course = new Course { Number = s.Course.Number },
            }).ToList();

            var studyGroupViewModel = new StudyGroupIndexViewModel { StudyGroups = studyGroupList };

            return View(studyGroupViewModel);
        }


        public ActionResult Create()
        {
            var facultyOptions = _dbContext.Faculties.ToDictionary(d => d.Id, d => d.Name);
            var coursesOptions = _dbContext.Courses.ToDictionary(d => d.Id, d => d.Number);
            var studyGroupViewModel = new StudyGroupCreateViewModel { FacultyOptions = facultyOptions, CourseOptions = coursesOptions };

            return View(studyGroupViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudyGroup studyGroup)
        {
            try
            {
                _dbContext.StudyGroups.Add(studyGroup);
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
                var studyGroup = _dbContext.StudyGroups.First(s=> s.Id==id);

                var facultyOptions = _dbContext.Faculties.ToDictionary(d => d.Id, d => d.Name);
                var coursesOptions = _dbContext.Courses.ToDictionary(d => d.Id, d => d.Number);

                var studyGroupViewModel = new StudyGroupCreateViewModel { StudyGroup = studyGroup, FacultyOptions = facultyOptions, CourseOptions = coursesOptions };

                return View(studyGroupViewModel);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudyGroup studyGroup)
        {
           
            try
            {

                _dbContext.StudyGroups.Update(studyGroup);
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
                var studyGroup = _dbContext.StudyGroups.First( s=> s.Id== id);

                _dbContext.StudyGroups.Remove(studyGroup);
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
