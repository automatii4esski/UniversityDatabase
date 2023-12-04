using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityDatabase.Data;
using UniversityDatabase.Models;
using UniversityDatabase.Seed;
using UniversityDatabase.ViewModels.Student;
using UniversityDatabase.ViewModels.StudyGroup;

namespace UniversityDatabase.Controllers
{
    public class StudentController : Controller
    {
        private MyDbContext _dbContext;

        public StudentController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var studentList = _dbContext.Students.Select(s =>
            new Student
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                Patronymic = s.Patronymic,
                SexNumber = s.SexNumber,
                DateOfBirth = s.DateOfBirth,
                StudyGroup = new StudyGroup { Name = s.StudyGroup.Name },
            }).ToList();

            var studentViewModel = new StudentIndexViewModel { Students = studentList };

            return View(studentViewModel);
        }


        public ActionResult Create()
        {
            var studyGroupOptions = _dbContext.StudyGroups.ToDictionary(s => s.Id, s => s.Name);

            var studentViewModel = new StudentCreateViewModel {  StudyGroupOptions = studyGroupOptions };

            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            bool isStudyGroupExist = _dbContext.StudyGroups.Any(s => s.Id == student.StudyGroupId);

            if (!isStudyGroupExist )
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var student = _dbContext.Students.Find(id);

            if (student == null) return RedirectToAction(nameof(Index));

            var studyGroupOptions = _dbContext.StudyGroups.ToDictionary(s => s.Id, s => s.Name);

            var studyGroupViewModel = new StudentCreateViewModel { Student = student, StudyGroupOptions = studyGroupOptions };

            return View(studyGroupViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            bool isStudyGroupExist = _dbContext.StudyGroups.Any(s => s.Id == student.StudyGroupId);

            if (!isStudyGroupExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Students.Update(student);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var student = _dbContext.Students.Find(id);

            if (student == null) return RedirectToAction(nameof(Index));

            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
