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
    public class User_RegistrationController : Controller
    {
        private OnlineTrainingDBEntities db = new OnlineTrainingDBEntities();

        // GET: User_Registration
        public ActionResult Index()
        {
            return View(db.User_Registration.ToList());
        }

        // GET: User_Registration/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Registration user_Registration = db.User_Registration.Find(id);
            if (user_Registration == null)
            {
                return HttpNotFound();
            }
            return View(user_Registration);
        }

        // GET: User_Registration/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User_Registration/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,FirstName,LastName,EmailAddress,Password")] User_Registration user_Registration)
        {
            if (ModelState.IsValid)
            {
                db.User_Registration.Add(user_Registration);
                db.SaveChanges();
                return RedirectToAction("Index","Login");
            }

            return View(user_Registration);
        }

        // GET: User_Registration/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Registration user_Registration = db.User_Registration.Find(id);
            if (user_Registration == null)
            {
                return HttpNotFound();
            }
            return View(user_Registration);
        }

        // POST: User_Registration/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,EmailAddress,Password")] User_Registration user_Registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Registration);
        }

        // GET: User_Registration/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Registration user_Registration = db.User_Registration.Find(id);
            if (user_Registration == null)
            {
                return HttpNotFound();
            }
            return View(user_Registration);
        }

        // POST: User_Registration/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User_Registration user_Registration = db.User_Registration.Find(id);
            db.User_Registration.Remove(user_Registration);
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
