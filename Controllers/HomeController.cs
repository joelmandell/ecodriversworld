using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace DataNissen.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
           return View("home");
        }

        public ContentResult IsSession()
        {
            if (Session["clicked"] != null)
            {
                return Content("Session is set");
            }
            else
            {
                return Content("Session is unset");
            }
        }
        
        [HttpPost]
        public ContentResult SetSession()
        {
            Session["clicked"] = "true";
            return IsSession();
        }

        [HttpPost]
        public ContentResult UnsetSession()
        {
            for (int i = 0; i < Session.Count; i++)
            {
                Session[i] = null;
            }
            return IsSession();
        }

    }
}
