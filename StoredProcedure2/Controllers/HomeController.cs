using StoredProcedure2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoredProcedure2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (MyDbContext context = new MyDbContext())
            {
                Candidate c = new Candidate
                {
                    Name = "Jane Doe",
                    Email = "Jane@gmail.com",
                    PhnNum = "9877899870",
                    DOB = "12-09-1997",
                    Gender = "Female",
                    UnivName = "Harvard",
                    ClgName = "Harvard",
                    Branch = "CS"
                };
                context.Candidates.Add(c);
                context.SaveChanges();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }


}

