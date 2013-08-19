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
            //Doing some testing in learning the FormCollection and
            //also to secure the data..
            try
            {
                string username = collection["username"];
                string password = collection["password"];
              //  string salt = cryptoService.GenerateSalt();
               // string hashedPassword = cryptoService.Compute(password.ToString());

                if (username.Contains("kalle"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Edit");
                }
            }
            catch
            {
                return View("Forum");
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
