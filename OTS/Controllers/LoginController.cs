using OTS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTS.Controllers
{
    public class LoginController : Controller
    {
        OnlineTrainingDBEntities db = new OnlineTrainingDBEntities();

       
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(User_Registration objchk)
        {
            if(ModelState.IsValid)
            {
                using (OnlineTrainingDBEntities db = new OnlineTrainingDBEntities())
                {
                    var obj = db.User_Registration.Where(a => a.EmailAddress.Equals(objchk.EmailAddress) && a.Password.Equals(objchk.Password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserName"] = obj.FirstName.ToString();
                        Session["UserId"] = obj.id.ToString();
                        Session["EmailAddress"] = obj.EmailAddress.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The Email Address or Password is incorrect");
                    }
                }
            }
            
            return View(objchk);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}