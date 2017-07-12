using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace NewABeginning.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Services()
        {
            return View();
        }

        // GET: About
        public ActionResult About()
        {
            return View();
        }

        // GET: Contact
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmailSubmit(string customerEmail, string customerRequest)
        {
            try {
                WebMail.Send(to: "someone@example.com", subject: "Help request from - " + customerEmail, body: customerRequest);
                return View();
            }catch (Exception ex )
            {
                 return View();
            }
        }       
    }
}