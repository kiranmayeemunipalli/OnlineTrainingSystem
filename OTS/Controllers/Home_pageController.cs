using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OTS.Models;

namespace OTS.Controllers
{
    public class Home_pageController : Controller
    {
        private OnlineTrainingDBEntities db = new OnlineTrainingDBEntities();

        // GET: Home_page
        public ActionResult Index()
        {
            return View(db.Home_page.ToList());
        }

        // GET: Home_page/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home_page home_page = db.Home_page.Find(id);
            if (home_page == null)
            {
                return HttpNotFound();
            }
            return View(home_page);
        }

        // GET: Home_page/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home_page/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TrainingName,StartDate,EndDate,Fees")] Home_page home_page)
        {
            if (ModelState.IsValid)
            {
                db.Home_page.Add(home_page);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(home_page);
        }

        // GET: Home_page/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home_page home_page = db.Home_page.Find(id);
            if (home_page == null)
            {
                return HttpNotFound();
            }
            return View(home_page);
        }

        // POST: Home_page/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TrainingName,StartDate,EndDate,Fees")] Home_page home_page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(home_page).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(home_page);
        }

        // GET: Home_page/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Home_page home_page = db.Home_page.Find(id);
            if (home_page == null)
            {
                return HttpNotFound();
            }
            return View(home_page);
        }

        // POST: Home_page/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Home_page home_page = db.Home_page.Find(id);
            db.Home_page.Remove(home_page);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
