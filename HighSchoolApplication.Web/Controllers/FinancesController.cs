using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HighSchoolApplication.Web.Controllers
{
    public class FinancesController : Controller
    {
        // GET: Finances
        public ActionResult Index()
        {
            return View();
        }

        // GET: Finances/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Finances/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Finances/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Finances/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Finances/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Finances/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Finances/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}