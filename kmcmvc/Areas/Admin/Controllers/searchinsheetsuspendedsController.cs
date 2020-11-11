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
    public class searchinsheetsuspendedsController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/searchinsheetsuspendeds
        public ActionResult Index()
        {
            return View(db.searchinsheetsuspendeds.ToList());
        }

        // GET: Admin/searchinsheetsuspendeds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            searchinsheetsuspended searchinsheetsuspended = db.searchinsheetsuspendeds.Find(id);
            if (searchinsheetsuspended == null)
            {
                return HttpNotFound();
            }
            return View(searchinsheetsuspended);
        }

        // GET: Admin/searchinsheetsuspendeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/searchinsheetsuspendeds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SSID,InwordNo,Consumer_No,Department,Zone,Twon,Createdon,Createdby")] searchinsheetsuspended searchinsheetsuspended)
        {
            if (ModelState.IsValid)
            {
                db.searchinsheetsuspendeds.Add(searchinsheetsuspended);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(searchinsheetsuspended);
        }

        // GET: Admin/searchinsheetsuspendeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            searchinsheetsuspended searchinsheetsuspended = db.searchinsheetsuspendeds.Find(id);
            if (searchinsheetsuspended == null)
            {
                return HttpNotFound();
            }
            return View(searchinsheetsuspended);
        }

        // POST: Admin/searchinsheetsuspendeds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SSID,InwordNo,Consumer_No,Department,Zone,Twon,Createdon,Createdby")] searchinsheetsuspended searchinsheetsuspended)
        {
            if (ModelState.IsValid)
            {
                db.Entry(searchinsheetsuspended).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(searchinsheetsuspended);
        }

        // GET: Admin/searchinsheetsuspendeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            searchinsheetsuspended searchinsheetsuspended = db.searchinsheetsuspendeds.Find(id);
            if (searchinsheetsuspended == null)
            {
                return HttpNotFound();
            }
            return View(searchinsheetsuspended);
        }

        // POST: Admin/searchinsheetsuspendeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            searchinsheetsuspended searchinsheetsuspended = db.searchinsheetsuspendeds.Find(id);
            db.searchinsheetsuspendeds.Remove(searchinsheetsuspended);
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
