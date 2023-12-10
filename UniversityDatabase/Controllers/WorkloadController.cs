﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using UniversityDatabase.Data;
using UniversityDatabase.Models;
using UniversityDatabase.Seed;
using UniversityDatabase.ViewModels.Teacher;
using UniversityDatabase.ViewModels.Workload;

namespace UniversityDatabase.Controllers
{
    public class WorkloadController : Controller
    {
        private MyDbContext _dbContext;

        public WorkloadController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ActionResult Index()
        {
            var workloadList = _dbContext.Workloads.Select(w =>
            new Workload
            {
                Id = w.Id,
                Teacher = new Teacher {Name= w.Teacher.Name, Surname= w.Teacher.Surname, Patronymic = w.Teacher.Patronymic },
                TotalHours = w.TotalHours,
                StudyPlan = new StudyPlan { Course = new Course {Number = w.StudyPlan.Course.Number }, 
                    Semester = new Semester { Number = w.StudyPlan.Semester.Number},
                    Subject = new Subject { Name = w.StudyPlan.Subject.Name},
                    TypeOfOccupation = new TypeOfOccupation { Name = w.StudyPlan.TypeOfOccupation.Name },
                    FormOfControl = new FormOfControl { Name = w.StudyPlan.FormOfControl.Name },
                }

            }).ToList();

            var workloadViewModel = new WorkloadIndexViewModel { Workloads = workloadList };

            return View(workloadViewModel);
        }

        public ActionResult Create(int studyPlanId, int teacherId)
        {
            var teacherWithThisStudyPlan = _dbContext.Workloads.FirstOrDefault(w=> w.TeacherId == teacherId && w.StudyPlanId == studyPlanId);

            if (teacherWithThisStudyPlan != null)
            {
                return RedirectToAction(nameof(Edit), new {id = teacherWithThisStudyPlan.Id});
            }

            var studyPlan = _dbContext.StudyPlans.Select(s => new StudyPlan
            {
                Id = s.Id,
                TotalHours = s.TotalHours,
                RemainingHours = s.RemainingHours,
                Course = new Course { Number = s.Course.Number },
                Semester = new Semester { Number = s.Semester.Number },
                Subject = new Subject { Name = s.Subject.Name },
                StudyGroup = new StudyGroup { Name = s.StudyGroup.Name },
                FormOfControl = new FormOfControl { Name = s.FormOfControl.Name },
                TypeOfOccupation = new TypeOfOccupation { Name = s.TypeOfOccupation.Name }
            }).FirstOrDefault(s => s.Id == studyPlanId);

            var teacher = _dbContext.Teachers.Select(t => new Teacher
            {
                Id = t.Id,
                Name= t.Name,
                Surname = t.Surname,
                Patronymic = t.Patronymic,
            }).FirstOrDefault(t => t.Id == teacherId);

            if(teacher == null || studyPlan == null)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            var workload = new Workload { StudyPlanId = studyPlanId, TeacherId = teacherId, StudyPlan = studyPlan, Teacher = teacher };
            var workloadViewModel = new WorkloadCreateViewModel { Workload = workload };

            return View(workloadViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Workload workload)
        {
            
            var studyPlan = _dbContext.StudyPlans.FirstOrDefault(s => s.Id == workload.StudyPlanId);
            bool isTeacherExist = _dbContext.Teachers.Any(t => t.Id == workload.TeacherId);

            if (studyPlan == null || !isTeacherExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            studyPlan.RemainingHours -= workload.TotalHours;

            if (studyPlan.RemainingHours < 0)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.StudyPlans.Update(studyPlan);
            _dbContext.Workloads.Add(workload);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
            var workload = _dbContext.Workloads.Find(id);

            if (workload == null) return RedirectToAction(nameof(Index));

            var studyPlan = _dbContext.StudyPlans.Select(s => new StudyPlan
            {
                Id = s.Id,
                TotalHours = s.TotalHours,
                RemainingHours = s.RemainingHours,
                Course = new Course { Number = s.Course.Number },
                Semester = new Semester { Number = s.Semester.Number },
                Subject = new Subject { Name = s.Subject.Name },
                StudyGroup = new StudyGroup { Name = s.StudyGroup.Name },
                FormOfControl = new FormOfControl { Name = s.FormOfControl.Name },
                TypeOfOccupation = new TypeOfOccupation { Name = s.TypeOfOccupation.Name }
            }).FirstOrDefault(s => s.Id == workload.StudyPlanId);

            var teacher = _dbContext.Teachers.Select(t => new Teacher
            {
                Id = t.Id,
                Name = t.Name,
                Surname = t.Surname,
                Patronymic = t.Patronymic,
            }).FirstOrDefault(t => t.Id == workload.TeacherId);

            if (studyPlan == null || teacher == null)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            workload.Teacher = teacher;
            workload.StudyPlan = studyPlan;

            var workloadViewModel = new WorkloadCreateViewModel { Workload = workload };

            return View(workloadViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Workload workload, int initialTotalHours)
        {
            var studyPlan = _dbContext.StudyPlans.Find(workload.StudyPlanId);
            bool isTeacherExist = _dbContext.Teachers.Any(t => t.Id == workload.TeacherId);

            if (studyPlan == null || !isTeacherExist)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            var totalHoursDiff = initialTotalHours - workload.TotalHours;
            studyPlan.RemainingHours += totalHoursDiff;

            if (studyPlan.RemainingHours < 0)
            {
                TempData["error"] = "error test";
                return RedirectToAction(nameof(Index));
            }

            _dbContext.Workloads.Update(workload);
            _dbContext.StudyPlans.Update(studyPlan);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var workload = _dbContext.Workloads.Find(id);

            if (workload == null) return RedirectToAction(nameof(Index));

            var studyPlan = _dbContext.StudyPlans.Find(workload.StudyPlanId);

            if (studyPlan == null) return RedirectToAction(nameof(Index));

            studyPlan.RemainingHours += workload.TotalHours;

            _dbContext.Workloads.Remove(workload);
            _dbContext.StudyPlans.Update(studyPlan);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}