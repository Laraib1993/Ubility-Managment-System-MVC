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
    public class muctemployeesController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/muctemployees
        public ActionResult Index()
        {
            return View(db.muctemployees.ToList());
        }

        // GET: Admin/muctemployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            muctemployee muctemployee = db.muctemployees.Find(id);
            if (muctemployee == null)
            {
                return HttpNotFound();
            }
            return View(muctemployee);
        }

        // GET: Admin/muctemployees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/muctemployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "muctempid,employee,designation")] muctemployee muctemployee)
        {
            if (ModelState.IsValid)
            {
                db.muctemployees.Add(muctemployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(muctemployee);
        }

        // GET: Admin/muctemployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            muctemployee muctemployee = db.muctemployees.Find(id);
            if (muctemployee == null)
            {
                return HttpNotFound();
            }
            return View(muctemployee);
        }

        // POST: Admin/muctemployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "muctempid,employee,designation")] muctemployee muctemployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(muctemployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(muctemployee);
        }

        // GET: Admin/muctemployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            muctemployee muctemployee = db.muctemployees.Find(id);
            if (muctemployee == null)
            {
                return HttpNotFound();
            }
            return View(muctemployee);
        }

        // POST: Admin/muctemployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            muctemployee muctemployee = db.muctemployees.Find(id);
            db.muctemployees.Remove(muctemployee);
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
