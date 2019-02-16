using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication30.Controllers
{
    public class ITController : Controller
    {
        // GET: IT
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Q1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Q1(string radio1)
        {
            string ans = "HyperText Markup Language";
            if(ans.Equals(radio1))
            {
                Session["marks"] = 1;
            }
          

            return RedirectToAction("Q2");
        }

        public ActionResult Q2()
        {
            return View();
        }
    }
}