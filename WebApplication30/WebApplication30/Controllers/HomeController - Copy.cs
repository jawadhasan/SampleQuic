using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication30.Models;

namespace WebApplication30.Controllers
{
    public class HomeController2 : Controller
    {
        dbQuiz17Entities db = new dbQuiz17Entities();
        

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public ActionResult Index(AdminLogin login)
        {
            if (login.Username == "admin" && login.Password == "admin")
            {
                return RedirectToAction("Index", "Student");
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult StdLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StdLogin(tblStudent std)
        {
            var count = db.tblStudents.Where(y => y.STD_ENROLL == std.STD_ENROLL && y.STD_PWD == std.STD_PWD).SingleOrDefault();

            if (count != null)
            {
                Session["user"] = count.STD_NAME;
                return RedirectToAction("Index", "IT");
            }
            else
            {
                return View();
            }
        }


    }
}