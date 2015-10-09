using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Competenct_Management.Models
{
    public class UserCapabilityController : Controller
    {
        private User_CapabilityDBContext db = new User_CapabilityDBContext();

        // GET: UserCapability
        public ActionResult Index()
        {
            return View(db.Capabilities.ToList());
        }

        // GET: UserCapability/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Capability user_Capability = db.Capabilities.Find(id);
            if (user_Capability == null)
            {
                return HttpNotFound();
            }
            return View(user_Capability);
        }

        // GET: UserCapability/Create
        public ActionResult Create()

        {
           return View();
        }

  
        // POST: UserCapability/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,System,SubSystem,Component,Description,Score")] User_Capability user_Capability)
        {
            if (ModelState.IsValid)
            {
                db.Capabilities.Add(user_Capability);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user_Capability);
        }

        // GET: UserCapability/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Capability user_Capability = db.Capabilities.Find(id);
            if (user_Capability == null)
            {
                return HttpNotFound();
            }
            return View(user_Capability);
        }

        // POST: UserCapability/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,System,SubSystem,Component,Description,Score")] User_Capability user_Capability)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user_Capability).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user_Capability);
        }

        // GET: UserCapability/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User_Capability user_Capability = db.Capabilities.Find(id);
            if (user_Capability == null)
            {
                return HttpNotFound();
            }
            return View(user_Capability);
        }

        // POST: UserCapability/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            User_Capability user_Capability = db.Capabilities.Find(id);
            db.Capabilities.Remove(user_Capability);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
