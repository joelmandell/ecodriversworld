﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace DataNissen.Controllers
{
    public class ForumController : Controller
    {
        //
        // GET: /Forum/

        private var db = new Forum();

        //private Models.MemberContainer db = new Models.MemberContainer();
        public ActionResult Index()
        {
            //List the subjects that is available
           // db.Set(
            return View("forum");
        }

        //
        // GET: /Forum/Subject/1
        public ActionResult Subject(int id)
        {
            return View();
        }

        //
        // GET: /Forum/Thread
        public ActionResult Thread(int id)
        {
            return View();
        }

        //
        // POST: /Forum/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Forum/MoveThread/5
        public ActionResult MoveThread(int sourceId, int targetId)
        {
            //string type can be subject or thread or post - those are editable entities.
            return View();
        }

        //
        // GET: /Forum/Edit/5
        public ActionResult Edit(int id, string type)
        {
            //string type can be subject or thread or post - those are editable entities.
            return View();
        }

        //
        // POST: /Forum/Edit/5

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
        // GET: /Forum/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Forum/Delete/5

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
