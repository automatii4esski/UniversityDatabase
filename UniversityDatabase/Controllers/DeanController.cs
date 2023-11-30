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

        public ActionResult Index()
        {
            var deansList = _dbContext.Deans.ToList();

            var deanViewModel = new DeanIndexViewModel { Deans = deansList };

            return View(deanViewModel);
        }

        public ActionResult Create()
        {
            var deanViewModel = new DeanCreateViewModel();
            return View(deanViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dean dean)
        {
            _dbContext.Deans.Add(dean);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public ActionResult Edit(int id)
        {
           var dean = _dbContext.Deans.Find(id);

            if (dean == null)return RedirectToAction(nameof(Index));

            var deanViewModel = new DeanCreateViewModel { Dean = dean };

            return View(deanViewModel);
        }

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
