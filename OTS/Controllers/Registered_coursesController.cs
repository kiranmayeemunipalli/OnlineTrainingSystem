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
    public class Registered_coursesController : Controller
    {
        private OnlineTrainingDBEntities db = new OnlineTrainingDBEntities();

        // GET: Registered_courses
        public ActionResult Index()
        {
            var registered_courses = db.Registered_courses.Include(r => r.Course_Registration);
            return View(registered_courses.ToList());
        }

        

                // GET: Registered_courses/Details/5
                public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registered_courses registered_courses = db.Registered_courses.Find(id);
            if (registered_courses == null)
            {
                return HttpNotFound();
            }
            return View(registered_courses);
        }

        // GET: Registered_courses/Create
        public ActionResult Create()
        {
            ViewBag.Course_id = new SelectList(db.Course_Registration, "id", "TrainingName");
            return View();
        }

        // POST: Registered_courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,TrainingName,EmailAddress,Fees,Status")] Registered_courses registered_courses,Home_page objchk1)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Registered_courses.Add(registered_courses);
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            if (ModelState.IsValid)
            {
                using (OnlineTrainingDBEntities db = new OnlineTrainingDBEntities())
                {
                    var obj1 = db.Home_page.Where(b => b.TrainingName == (objchk1.TrainingName) && b.Fees == (objchk1.Fees)).FirstOrDefault();
                    if (obj1 != null)
                    {
                        Session["CourseId"] = obj1.id.ToString();
                        Session["TrainingName"] = obj1.TrainingName.ToString();
                        Session["Fees"] = obj1.Fees.ToString();
                        db.Registered_courses.Add(registered_courses);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                        //return RedirectToAction("Index", "Registered_courses");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The TrainingName or Fees entered is incorrect");
                    }
                }
            }

            ViewBag.Course_id = new SelectList(db.Course_Registration, "id", "TrainingName",registered_courses.Course_id);
            return View(registered_courses);
        }


        // GET: Registered_courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registered_courses registered_courses = db.Registered_courses.Find(id);
            if (registered_courses == null)
            {
                return HttpNotFound();
            }
            ViewBag.Course_id = new SelectList(db.Course_Registration, "id", "TrainingName", registered_courses.Course_id);
            return View(registered_courses);
        }

        // POST: Registered_courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,TrainingName,Course_id,FirstName,EmailAddress,Fees,Status")] Registered_courses registered_courses)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registered_courses).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Course_id = new SelectList(db.Course_Registration, "id", "TrainingName", registered_courses.Course_id);
            return View(registered_courses);
        }

        // GET: Registered_courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registered_courses registered_courses = db.Registered_courses.Find(id);
            if (registered_courses == null)
            {
                return HttpNotFound();
            }
            return View(registered_courses);
        }

        // POST: Registered_courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registered_courses registered_courses = db.Registered_courses.Find(id);
            db.Registered_courses.Remove(registered_courses);
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
