using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityDatabase.Data;
using UniversityDatabase.Models;
using UniversityDatabase.ViewModels.Dean;

namespace UniversityDatabase.Controllers
{
    public class DeanController : Controller
    {
        private MyDbContext _dbContext;

        public DeanController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: DeanController
        public ActionResult Index()
        {
            var deansList = _dbContext.Deans.ToList();

            var deanViewModel = new DeanIndexViewModel { Deans = deansList };

            return View(deanViewModel);
        }

        // GET: DeanController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DeanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DeanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dean dean)
        {
            if (!ModelState.IsValid) return RedirectToAction(nameof(Create));

            _dbContext.Deans.Add(dean);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: DeanController/Edit/5
        public ActionResult Edit(int id)
        {
           var dean = _dbContext.Deans.Find(id);

            if (dean == null)return RedirectToAction(nameof(Index));

            return View(dean);
        }

        // POST: DeanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dean dean)
        {
            _dbContext.Deans.Update(dean);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


        // POST: DeanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var dean = _dbContext.Deans.Find(id);

            if (dean == null) return RedirectToAction(nameof(Index));

            _dbContext.Deans.Remove(dean);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
