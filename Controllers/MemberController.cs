using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DataNissen.Models;
using SimpleCrypto;
using Recaptcha;
using Recaptcha.Web.Mvc;
using Postal;
using Recaptcha.Web;

namespace DataNissen.Controllers
{
    public class MemberController : Controller
    {

        private MemberModel db = new MemberModel();

        public ActionResult Send(string message)
        {
            dynamic email = new Email("Example");
            email.To = "test@example.com";
            email.Message = message;
            email.Send();

            return RedirectToAction("Sent");
        }

        //
        // GET: /Member/
        public ActionResult Index()
        {
            return View("Member");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            //model.Member.Find(1);
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();

            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("captcha", "Denna måste fyllas i.");
                return View(model);
            }

            RecaptchaVerificationResult recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();

            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("captcha", "Du har inte skrivit rätt tecken.");
                return View(model);
            }

            if (ModelState.IsValid)
            {
                //db.Entry(member).State = EntityState.Modified;
               // db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View();
        }

        //
        // GET: /Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            //SimpleCrypto used to create salts and hashes.
            ICryptoService cryptoService = new PBKDF2();
            Exception e = new Exception();

            var member = new MemberModel();

            try
            {

                member.Member.Add(new Member { UserName = "dikatlon" });

                string username = collection["username"];
                string password = collection["password"];
                string salt = cryptoService.GenerateSalt(); ;

                if (username == "" || password == "")
                {
                    e.Source = "Du har inte fyllt i fälten för lösenord eller användarnamn.";
                    throw e;
                }
                else
                {
                    string hashedPassword = cryptoService.Compute(password.ToString(), salt);
                    Session["hash"] = member.Member.Find(0).UserName;
                }

                if (password != "")
                {

                }
                else
                {
                    Session["hash"] = "";
                }

                if (username.Contains("kalle"))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    e.Source = "rrr";
                    throw e;
                }
            }
            catch
            {

                TempData["errorData"] = e.Source;
                return RedirectToAction("Index", "Member");
            }
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
            string username = collection["username"];
            string password = collection["password"];
            string email = collection["email"];

            return View();
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
