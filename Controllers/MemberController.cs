using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DataNissen.Models;
using SimpleCrypto;

namespace DataNissen.Controllers
{
    public class MemberController : Controller
    {
        //
        // GET: /Member/

        private MemberModel member = new MemberModel();

        //SimpleCrypto used to create salts and hashes.
        ICryptoService cryptoService = new PBKDF2();

        public ActionResult Index()
        {
            return View("Member");
        }

        public ActionResult Register()
        {
            return View("Register");
        }

        //
        // GET: /Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Member/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Member/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            Exception e = new Exception();
            try
            {
                string username = collection["username"];
                string password = collection["password"];
                string salt = cryptoService.GenerateSalt();

                Uri Ref = Request.UrlReferrer;

                //Is the host allowed? This is done in order to disable cross-scripting from other domain or host, only
                if (RouteConfig.AllowedHost() != Ref.Host)
                {
                    e.Source = "Anrop ej tillåtet.";
                    throw e;
                }

                if (username == "" || password == "")
                {
                    e.Source = "Du har inte fyllt i fälten för lösenord eller användarnamn.";
                    throw e;
                } else {
                    string hashedPassword = cryptoService.Compute(password.ToString());
                    Session["hash"] = hashedPassword;
                }


                if (password != "")
                {

                }
                else
                {
                    Session["hash"] ="";
                }

                if (username.Contains("kalle"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    e.Source = "";
                    throw e;                
                }
            }
            catch
            {

                TempData["errorData"] = e.Source;
                return RedirectToAction("Index","Member");
            }
        }

        //
        // GET: /Member/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Member/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
