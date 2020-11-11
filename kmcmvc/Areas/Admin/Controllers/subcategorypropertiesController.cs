using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using kmcmvc.Areas.Admin.Data;

namespace kmcmvc.Areas.Admin.Controllers
{
    public class subcategorypropertiesController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/subcategoryproperties
        public ActionResult Index()
        {
            return View(db.subcategoryproperties.ToList());
        }

        // GET: Admin/subcategoryproperties/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoryproperty subcategoryproperty = db.subcategoryproperties.Find(id);
            if (subcategoryproperty == null)
            {
                return HttpNotFound();
            }
            return View(subcategoryproperty);
        }

        // GET: Admin/subcategoryproperties/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/subcategoryproperties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCategoryID,SubCategoryName,subcategorycode,PropertyTypeID,Status")] subcategoryproperty subcategoryproperty)
        {
            if (ModelState.IsValid)
            {
                db.subcategoryproperties.Add(subcategoryproperty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subcategoryproperty);
        }

        // GET: Admin/subcategoryproperties/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoryproperty subcategoryproperty = db.subcategoryproperties.Find(id);
            if (subcategoryproperty == null)
            {
                return HttpNotFound();
            }
            return View(subcategoryproperty);
        }

        // POST: Admin/subcategoryproperties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCategoryID,SubCategoryName,subcategorycode,PropertyTypeID,Status")] subcategoryproperty subcategoryproperty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subcategoryproperty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subcategoryproperty);
        }

        // GET: Admin/subcategoryproperties/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            subcategoryproperty subcategoryproperty = db.subcategoryproperties.Find(id);
            if (subcategoryproperty == null)
            {
                return HttpNotFound();
            }
            return View(subcategoryproperty);
        }

        // POST: Admin/subcategoryproperties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            subcategoryproperty subcategoryproperty = db.subcategoryproperties.Find(id);
            db.subcategoryproperties.Remove(subcategoryproperty);
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
