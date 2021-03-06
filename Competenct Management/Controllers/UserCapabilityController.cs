﻿using System;
using System.Collections.Generic;
using Competenct_Management.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;


namespace Competenct_Management.Controllers
{/// <summary>
/// 
/// </summary>
    public class UserCapabilityController : Controller
    {
        public static IList<User_Capability> _persons = new List<User_Capability>()
        {
            new User_Capability {PersonId = 1, PersonName = "Peter Barnard", SubSystem = "BMS Engineering", Component = "Legislation", Description = "Leg", Score = 3},
            new User_Capability {PersonId = 1, PersonName = "Peter Barnard", SubSystem = "BMS Engineering", Component = "Design", Description = "Architectual", Score = 2},
            new User_Capability {PersonId = 1, PersonName = "Will Johnston", SubSystem = "C&S Engineering", Component = "Work", Description = "wk", Score = 3}
        };

        #region MockData

        public List<string> SysList = new List<string>()
        {
            "CCTV", "BMS", "C&S"
        };

        public static List<SubSystemDropDownLink> ssdl = new List<SubSystemDropDownLink>()
        {
            new SubSystemDropDownLink { System = "CCTV", SubSystem = "Engineering" },
            new SubSystemDropDownLink { System = "CCTV", SubSystem = "Related Engineering" },
            new SubSystemDropDownLink { System = "BMS", SubSystem = "Engineering" },
            new SubSystemDropDownLink { System = "BMS", SubSystem = "Related Engineering" }
            
        };

        public static List<Component> ssCompddl = new List<Component>()
        {
            new Component { componentId = "CCTV-Engineering", component = "Legislation" },
            new Component { componentId = "CCTV-Engineering", component = "Standards" },
            new Component { componentId = "CCTV-Related Engineering", component = "M&E"  },
            new Component { componentId = "BMS-Engineering", component = "Legislation"},
            new Component { componentId = "BMS-Related Engineering", component = "Electrical" }
        };

        public static List<Description> ssDescdddl = new List<Description>()
        {
            new Description { descriptionId = "CCTV-Engineering-Legislation", description = "Data Protection Act"},
            new Description { descriptionId = "CCTV-Related Engineering-M&E", description = "Cable and Containment Requirments"},
            new Description { descriptionId = "BMS-Engineering-Legislation", description = "Building Regulations"},
            new Description { descriptionId = "BMS-Related Engineering-Electrical", description = "HV switchgear / switchboards" }
        };

        #endregion

        ///private User_CapabilityDBContext db = new User_CapabilityDBContext();

        // GET: UserCapability
        public ActionResult Index()
         {
            IEnumerable<SelectListItem> items =
                from s in SysList
                select new SelectListItem
                {
                    Text = s,
                    Value = s
                };

            ViewBag.SystemsListItems = items;
             return View(_persons);
         }

        [HttpPost]
        public JsonResult GetSubSystemsList(string systemName)
        {

            return Json(from ss in ssdl
                        where ss.System == systemName
                        select new {ss.System, ss.SubSystem}
                        );
        }

        [HttpPost]
        public JsonResult GetComponentList(string subsystName)
        {
            return Json(from c in ssCompddl
                        where c.componentId == subsystName
                        select new {c.componentId, c.component }
                        );
        }

        [HttpPost]
        public JsonResult GetDescriptionList(string compName)
        {
            return Json(from d in ssDescdddl
                        where d.descriptionId == compName
                        select new {d.descriptionId, d.description }
                        );
        }

        //// GET: UserCapability/Details/5
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    User_Capability user_Capability = db.Capabilities.Find(id);
        //    if (user_Capability == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(user_Capability);
        //}

        //// GET: UserCapability/Create
        //public ActionResult Create()

        //{
        //    return View(new User_Capability());
        //}



        //// POST: UserCapability/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,System,SubSystem,Component,Description,Score")] User_Capability user_Capability)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Capabilities.Add(user_Capability);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(user_Capability);
        //}

        /// <summary>
        /// Edits our user caps
        /// </summary>
        /// <param name="id"> User ID Not Company ID!</param>
        /// <returns></returns>
        public ViewResult Edit(int id)
        {
            User_Capability personToEdit = (from p in _persons where p.PersonId == id select p).Single();
            //TODO review use of linq below, this was working before, I think. ML
            //personToEdit.System = (from s in SubSystems where s.SubSystem == personToEdit.SubSystem)
            return View("Create", personToEdit);
        }

        //[HttpPost]
        //public JsonResult SystemList()
        //{
        //    return Json(Systems);
        //}

        //[HttpPost]
        //public JsonResult SubSystemList(string System)
        //{
        //    return Json(from s in Subsystems
        //                where s.System == System
        //                select new { s.SubSystem });
        //}

        //[HttpPost]
        //public JsonResult ComponentList(string Component)
        //{
        //    return Json(from c in Component
        //                where c.Component == Component
        //                select new { s.Component });
        //}

        //[HttpPost]
        //public JsonResult DescriptionList(string Decription)
        //{
        //    return Json(from d in Description
        //                where d.Description == Decription
        //                select new { s.Description });
        //}

        //[HttpPost]
        //public JsonResult ScoreList(int Score)
        //{
        //    return Json(from ss in Score
        //                where ss.Score == Score
        //                select new { ss.Score });
        //}

        //public List<Systemtbl> Systems
        //{
        //    get
        //    {
        //        return new List<Systemtbl>()
        //        {
        //            new Systemtbl {System = "BMS" },
        //            new Systemtbl { System = "C&S" },
        //            new Systemtbl { System = "CCTV" },
        //        };
        //    }
        //}

        //public list<subsystemtbl> subsystems
        //{
        //    get
        //    {
        //        return new list<subsystemtbl>()
        //        {
        //            new subsystemtbl { system = "bms", subsystem = "bms engineering" },
        //            new subsystemtbl { system = "c&s", subsystem = "c&s engineering" },
        //            new subsystemtbl { system = "cctv", subsystem = "cctv engineering" }
        //        };
        //    }
        //}

        //public List<Componenttbl> Components
        //{
        //    get
        //    {
        //        return new List<Componenttbl>()
        //        {
        //            new Componenttbl { SubSystem = "BMS Engineering" },
        //            new Componenttbl { System = "C&S" },
        //            new Componenttbl { System = "CCTV" },
        //        };
        //    }
        //}
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
