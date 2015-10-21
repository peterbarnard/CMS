using System;
using System.Collections.Generic;
using Competenct_Management.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Competenct_Management.Models;

namespace Competenct_Management.Models
{
    public class UserCapabilityController : Controller
    {
        public static IList<User_Capability> _persons = new List<User_Capability>()
        {
            new User_Capability {PersonId = 1, PersonName = "Peter Barnard",SubSystem = "BMS Engineering", Component = "Legislation", Description = "Leg", Score = 3}
            new User_Capability {PersonId = 1, PersonName = "Peter Barnard",SubSystem = "BMS Engineering", Component = "Design", Description = "Architectual", Score = 2}
            new User_Capability {PersonId = 1, PersonName = "Will Johnston",SubSystem = "C&S Engineering", Component = "Work", Description = "wk", Score = 3}
        };
        //private User_CapabilityDBContext db = new User_CapabilityDBContext();

        // GET: UserCapability
        /* public ActionResult Index()
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
             return View(new User_Capability());
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
         }*/

        // GET: UserCapability/Edit/5
        public ViewResult Edit(int id)
        {
            User_Capability personToEdit = (from p in _persons where p.PersonId == id select p).Single();
            personToEdit.System = (from s in SubSystems where s.SubSystem == personToEdit.SubSystem)
            return View("Create", personToEdit);
        }

        [HttpPost]
        public JsonResult SystemList()
        {
            return Json(Systems);
        }

        [HttpPost]
        public JsonResult SubSystemList(string System)
        {
            return Json(from s in Subsystems
                        where s.System == System
                        select new { s.SubSystem });
        }

        [HttpPost]
        public JsonResult ComponentList(string Component)
        {
            return Json(from c in Component
                        where c.Component == Component
                        select new { s.Component });
        }

        [HttpPost]
        public JsonResult DescriptionList(string Decription)
        {
            return Json(from d in Description
                        where d.Description == Decription
                        select new { s.Description });
        }

        [HttpPost]
        public JsonResult ScoreList(int Score)
        {
            return Json(from ss in Score
                        where ss.Score == Score
                        select new { ss.Score });
        }

        public List<Systemtbl> Systems
        {
            get
            {
                return new List<Systemtbl>()
                {
                    new Systemtbl {System = "BMS" },
                    new Systemtbl { System = "C&S" },
                    new Systemtbl { System = "CCTV" },
                };
            }
        }

        public List<SubSystemtbl> SubSystems
        {
            get
            {
                return new List<SubSystemtbl>()
                {
                    new SubSystemtbl { System = "BMS", SubSystem = "BMS Engineering" },
                    new SubSystemtbl { System = "C&S", SubSystem = "C&S Engineering" },
                    new SubSystemtbl { System = "CCTV", SubSystem = "CCTV Engineering" }
                };
            }
        }

        public List<Componenttbl> Components
        {
            get
            {
                return new List<Componenttbl>()
                {
                    new Componenttbl { SubSystem = "BMS Engineering" },
                    new Componenttbl { System = "C&S" },
                    new Componenttbl { System = "CCTV" },
                };
            }
        }
    }
}

        // POST: UserCapability/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
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
 }*/
