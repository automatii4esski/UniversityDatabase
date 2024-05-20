using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityDatabase.Data;
using UniversityDatabase.Filters;
using UniversityDatabase.Models;
using UniversityDatabase.Seed;
using UniversityDatabase.ViewModels.Student;
using UniversityDatabase.ViewModels.StudentGrade;
using UniversityDatabase.ViewModels.StudyGroup;
using UniversityDatabase.Helpers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace UniversityDatabase.Controllers
{
    public class StudentController : Controller
    {
        private MyDbContext _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public StudentController(MyDbContext dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }

        private StudentIndexViewModel GetIndexViewModelWithOptions()
        {
            var sexOptions = _dbContext.Sexes.ToDictionary(s => s.Id, s => s.Name);
            var StudyGroupOptions = _dbContext.StudyGroups.ToDictionary(s => s.Id, s => s.Name);
            var CourseOptions = _dbContext.Courses.ToDictionary(s => s.Id, s => s.Number);
            var facultyOptions = _dbContext.Faculties.ToDictionary(s => s.Id, s => s.Name);

            var studentViewModel = new StudentIndexViewModel
            {
                SexOptions = sexOptions,
                StudyGroupOptions = StudyGroupOptions,
                CourseOptions = CourseOptions,
                FacultyOptions = facultyOptions,
            };

            return studentViewModel;
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
                Sex = new Sex { Name = s.Sex.Name },
                DateOfBirth = s.DateOfBirth,
                PhotoUrl = s.PhotoUrl,
                StudyGroup = new StudyGroup { Name = s.StudyGroup.Name },
                StudyGroupId = s.StudyGroupId
            }).ToList();

            var studentViewModel = GetIndexViewModelWithOptions();
            studentViewModel.Students = studentList;

            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? studyGroupId, byte? sexId, byte? courseId, int? facultyId, int? minAge, int? maxAge)
        {
            var studentList = _dbContext.Students.Select(s =>
            new Student
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                Patronymic = s.Patronymic,
                Sex = new Sex { Name = s.Sex.Name },
                DateOfBirth = s.DateOfBirth,
                PhotoUrl = s.PhotoUrl,
                StudyGroup = new StudyGroup { Name = s.StudyGroup.Name, FacultyId = s.StudyGroup.FacultyId, CourseId = s.StudyGroup.CourseId },
                SexId = s.SexId,
                StudyGroupId = s.StudyGroupId
            }).AsEnumerable();


            var filter = new StudentFilter { MinAge = minAge, MaxAge = maxAge, StudyGroupId = studyGroupId, SexId = sexId, CourseId = courseId, FacultyId = facultyId};
            var filteredStudents = filter.GetFilteredStudents(studentList).ToList();

            var studentViewModel = GetIndexViewModelWithOptions();
            studentViewModel.Filter = filter;
            studentViewModel.Students = filteredStudents;


            return View(studentViewModel);
        }

        public ActionResult Details(int id)
        {
            
            try
            {
                var student = _dbContext.Students.Select(s =>
            new Student
            {
                Id = s.Id,
                Name = s.Name,
                Surname = s.Surname,
                Patronymic = s.Patronymic,
                PhotoUrl = s.PhotoUrl,
                Sex = new Sex { Name = s.Sex.Name },
                DateOfBirth = s.DateOfBirth,
                StudyGroup = new StudyGroup { Name = s.StudyGroup.Name, Faculty = new Faculty { Name = s.StudyGroup.Faculty.Name }, Course = new Course { Number = s.StudyGroup.Course.Number } },
            }).First(s => s.Id == id);

                var studentGrades = _dbContext.StudentGrades.Where(s => s.StudentId == id).Select(s =>
                new StudentGrade
                {
                    Id = s.Id,
                    GradeValue = new GradeValue { Value = s.GradeValue.Value },
                    StudyPlan = new StudyPlan
                    {
                        Course = new Course { Number = s.StudyPlan.Course.Number },
                        Semester = new Semester { Number = s.StudyPlan.Semester.Number },
                        Subject = new Subject { Name = s.StudyPlan.Subject.Name },
                    }
                }).ToList();
                var viewModel = new StudentDetailsViewModel { Student = student, StudentGrades = studentGrades };

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
            var studyGroupOptions = _dbContext.StudyGroups.ToDictionary(s => s.Id, s => s.Name);
            var sexOptions  = _dbContext.Sexes.ToDictionary(s => s.Id, s => s.Name);

            var studentViewModel = new StudentCreateViewModel { SexOptions = sexOptions,  StudyGroupOptions = studyGroupOptions };

            return View(studentViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentCreateViewModel viewModel)
        {
            
            try
            {
                var studyPlansIdOfNewStudyGroup = _dbContext.StudyPlans.Where(s => s.StudyGroupId == viewModel.Student.StudyGroupId).Select(s => s.Id);

                string? photoName = FileHelper.SavePhoto(_hostingEnvironment, viewModel.Photo);
                viewModel.Student.PhotoUrl = photoName;

                _dbContext.Students.Add(viewModel.Student);
                _dbContext.SaveChanges();

                foreach (var studyPlan in studyPlansIdOfNewStudyGroup)
                {
                    _dbContext.StudentGrades.Add(new StudentGrade { StudentId = viewModel.Student.Id, StudyPlanId = studyPlan });
                }

                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public ActionResult ChangePhoto(int id)
        {
            var viewModel = new StudentChangePhotoViewModel { StudentId = id };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePhoto(StudentChangePhotoViewModel viewModel)
        {
            try
            {
                var photoName = FileHelper.SavePhoto(_hostingEnvironment, viewModel.Photo);

                var student = _dbContext.Students.First(s => s.Id == viewModel.StudentId);

                FileHelper.DeletePhoto(_hostingEnvironment, student.PhotoUrl);

                student.PhotoUrl = photoName;

                _dbContext.Students.Update(student);

                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = viewModel.StudentId });
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Details), new {id = viewModel.StudentId});
            }
        }

        public ActionResult Edit(int id)
        {
            
            try
            {
                var student = _dbContext.Students.First(s=> s.Id == id);

                var studyGroupOptions = _dbContext.StudyGroups.ToDictionary(s => s.Id, s => s.Name);
                var sexOptions = _dbContext.Sexes.ToDictionary(s => s.Id, s => s.Name);

                var studyGroupViewModel = new StudentCreateViewModel { Student = student, SexOptions = sexOptions, StudyGroupOptions = studyGroupOptions };

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
        public ActionResult Edit(StudentCreateViewModel viewModel, int initialStudyGroupId)
        {
            try
            {
                if (viewModel.Student.StudyGroupId != initialStudyGroupId)
                {
                    var studentGrades = _dbContext.StudentGrades.Where(s => s.StudentId == viewModel.Student.Id);
                    _dbContext.StudentGrades.RemoveRange(studentGrades);

                    var studyPlansIdOfNewStudyGroup = _dbContext.StudyPlans.Where(s => s.StudyGroupId == viewModel.Student.StudyGroupId).Select(s => s.Id);

                    foreach (var studyPlan in studyPlansIdOfNewStudyGroup)
                    {
                        _dbContext.StudentGrades.Add(new StudentGrade { StudentId = viewModel.Student.Id, StudyPlanId = studyPlan });
                    }
                }

                _dbContext.Students.Update(viewModel.Student);
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Details), new { id = viewModel.Student.Id });
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Details), new { id = viewModel.Student.Id });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var student = _dbContext.Students.First( s=> s.Id == id);

                FileHelper.DeletePhoto(_hostingEnvironment, student.PhotoUrl);

                var studentGrades = _dbContext.StudentGrades.Where(s => s.StudentId == id);
                _dbContext.StudentGrades.RemoveRange(studentGrades);

                _dbContext.Students.Remove(student);
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
