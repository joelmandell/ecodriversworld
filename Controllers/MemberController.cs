using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataNissen.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        public ActionResult Index()
        {
            return View("member");
        }

        public ActionResult Register()
        {
            //Should return view later on from Views/Member/{View}.cshtml
            return View("register");
        }

    }
}
