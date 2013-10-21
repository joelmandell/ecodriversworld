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
        
            try
            {
                string username = collection["username"];
                string password = collection["password"];
                Uri Ref = Request.UrlReferrer;

                Session["ref"] = Ref.Host;

                string salt = cryptoService.GenerateSalt();

                if (password != "")
                {
                    string hashedPassword = cryptoService.Compute(password.ToString());
                    Session["hash"] = hashedPassword;
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
                    ViewBag.errorData = "Not nice username!";

                    return View("Index");

                   // return RedirectToAction("Edit",5);
                }
            }
            catch
            {
                return Redirect("/Member/");
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
