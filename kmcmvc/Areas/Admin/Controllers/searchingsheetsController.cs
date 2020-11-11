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
    public class searchingsheetsController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/searchingsheets
        public ActionResult Index()
        {
            return View(db.searchingsheets.ToList());
        }

        // GET: Admin/searchingsheets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            searchingsheet searchingsheet = db.searchingsheets.Find(id);
            if (searchingsheet == null)
            {
                return HttpNotFound();
            }
            return View(searchingsheet);
        }

        // GET: Admin/searchingsheets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/searchingsheets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SearchID,inword,consumer_no,zone,Createdby,createdon")] searchingsheet searchingsheet)
        {
            if (ModelState.IsValid)
            {
                db.searchingsheets.Add(searchingsheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(searchingsheet);
        }

        // GET: Admin/searchingsheets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            searchingsheet searchingsheet = db.searchingsheets.Find(id);
            if (searchingsheet == null)
            {
                return HttpNotFound();
            }
            return View(searchingsheet);
        }

        // POST: Admin/searchingsheets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SearchID,inword,consumer_no,zone,Createdby,createdon")] searchingsheet searchingsheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(searchingsheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(searchingsheet);
        }

        // GET: Admin/searchingsheets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            searchingsheet searchingsheet = db.searchingsheets.Find(id);
            if (searchingsheet == null)
            {
                return HttpNotFound();
            }
            return View(searchingsheet);
        }

        // POST: Admin/searchingsheets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            searchingsheet searchingsheet = db.searchingsheets.Find(id);
            db.searchingsheets.Remove(searchingsheet);
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
