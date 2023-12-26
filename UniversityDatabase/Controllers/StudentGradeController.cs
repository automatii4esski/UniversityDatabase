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
using UniversityDatabase.ViewModels.Workload;

namespace UniversityDatabase.Controllers
{
    public class StudentGradeController : Controller
    {
        private MyDbContext _dbContext;

        public StudentGradeController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private StudentGradeIndexViewMode GetIndexViewModelWithOptions()
        {
            var StudyGroupOptions = _dbContext.StudyGroups.ToDictionary(s => s.Id, s => s.Name);
            var subjectOptions = _dbContext.Subjects.ToDictionary(s => s.Id, s => s.Name);
            var gradeValueOptions = _dbContext.GradeValues.ToDictionary(s => s.Id, s => s.Value);
            var courseOptions = _dbContext.Courses.ToDictionary(s => s.Id, s => s.Number);
            var semesterOptions = _dbContext.Semesters.ToDictionary(s => s.Id, s => s.Number);

            var studentGradeViewModel = new StudentGradeIndexViewMode
            {
                StudyGroupOptions = StudyGroupOptions,
                SubjectOptions = subjectOptions,
                GradeValueOptions = gradeValueOptions,
                CourseOptions = courseOptions,
                SemesterOptions = semesterOptions,
            };

            return studentGradeViewModel;
        }

        public ActionResult Index()
        {
            var studentGradeList = _dbContext.StudentGrades.Select(s =>
            new StudentGrade
            {
                Id = s.Id,
                GradeValueId = s.GradeValueId,
                GradeValue = new GradeValue { Value = s.GradeValue.Value},
                Student = new Student { Name = s.Student.Name, Surname = s.Student.Surname, Patronymic = s.Student.Patronymic },
                StudyPlan = new StudyPlan { StudyGroup = new StudyGroup { Name= s.StudyPlan.StudyGroup.Name}, 
                                            Course = new Course { Number = s.StudyPlan.Course.Number},
                                            Semester = new Semester { Number = s.StudyPlan.Semester.Number},
                                            Subject = new Subject { Name = s.StudyPlan.Subject.Name },
                }
            }).ToList();

            var studentGradeViewModel = GetIndexViewModelWithOptions();
            studentGradeViewModel.StudentGrades = studentGradeList;

            return View(studentGradeViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int? subjectId, List<byte?> gradeValueId, int? studyGroupId, byte? courseId, byte? semesterId)
        {
            var studentGradeList = _dbContext.StudentGrades.Select(s =>
            new StudentGrade
            {
                Id = s.Id,
                GradeValueId = s.GradeValueId,
                GradeValue = new GradeValue { Value = s.GradeValue.Value },
                Student = new Student { Name = s.Student.Name, Surname = s.Student.Surname, Patronymic = s.Student.Patronymic },
                StudyPlan = new StudyPlan
                {
                    StudyGroup = new StudyGroup { Name = s.StudyPlan.StudyGroup.Name },
                    StudyGroupId = s.StudyPlan.StudyGroupId,
                    SubjectId = s.StudyPlan.SubjectId,
                    Course = new Course { Number = s.StudyPlan.Course.Number },
                    CourseId = s.StudyPlan.CourseId,
                    SemesterId = s.StudyPlan.SemesterId,
                    Semester = new Semester { Number = s.StudyPlan.Semester.Number },
                    Subject = new Subject { Name = s.StudyPlan.Subject.Name },
                }
            }).AsEnumerable();

            var studentGradeViewModel = GetIndexViewModelWithOptions();
            var filter = new StudentGradeFilter { SubjectId = subjectId, StudyGroupId = studyGroupId, GradeValueId = gradeValueId, CourseId= courseId, SemesterId = semesterId };
            studentGradeViewModel.StudentGrades = filter.GetFilteredStudentGrades(studentGradeList).ToList() ;
            studentGradeViewModel.Filter = filter;

            return View(studentGradeViewModel);
        }

        public ActionResult Edit(int id, string? backUrl)
        {
            
            try
            {
                var studentGrade = _dbContext.StudentGrades.Include(s => s.StudyPlan).First(s => s.Id == id);

                var gradeValueOptions = _dbContext.GradeValues.Where(s => s.FormOfControlId == studentGrade.StudyPlan.FormOfControlId).ToDictionary(s => s.Id, s => s.Value);

                var studentGradeCreateViewModel = new StudentGradeCreateViewMode { StudentGrade = studentGrade, GradeValueOptions = gradeValueOptions, BackUrl = backUrl };

                return View(studentGradeCreateViewModel);
            }
            catch (Exception e)
            {

                TempData["error"] = e.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StudentGrade studentGrade, string? backUrl)
        {
            try
            {
                _dbContext.StudentGrades.Update(studentGrade);
                _dbContext.SaveChanges();

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
