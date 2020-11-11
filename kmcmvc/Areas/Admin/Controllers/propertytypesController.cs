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
    public class propertytypesController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/propertytypes
        public ActionResult Index()
        {
            return View(db.propertytypes.ToList());
        }

        // GET: Admin/propertytypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propertytype propertytype = db.propertytypes.Find(id);
            if (propertytype == null)
            {
                return HttpNotFound();
            }
            return View(propertytype);
        }

        // GET: Admin/propertytypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/propertytypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "propertyTypeID,propertyTypeName,PropertyCode,SizeIn")] propertytype propertytype)
        {
            if (ModelState.IsValid)
            {
                db.propertytypes.Add(propertytype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propertytype);
        }

        // GET: Admin/propertytypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propertytype propertytype = db.propertytypes.Find(id);
            if (propertytype == null)
            {
                return HttpNotFound();
            }
            return View(propertytype);
        }

        // POST: Admin/propertytypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "propertyTypeID,propertyTypeName,PropertyCode,SizeIn")] propertytype propertytype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propertytype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propertytype);
        }

        // GET: Admin/propertytypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propertytype propertytype = db.propertytypes.Find(id);
            if (propertytype == null)
            {
                return HttpNotFound();
            }
            return View(propertytype);
        }

        // POST: Admin/propertytypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            propertytype propertytype = db.propertytypes.Find(id);
            db.propertytypes.Remove(propertytype);
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
