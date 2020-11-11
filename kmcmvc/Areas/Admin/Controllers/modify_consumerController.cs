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
    public class modify_consumerController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/modify_consumer
        public ActionResult Index()
        {
            return View(db.modify_consumer.ToList());
        }

        // GET: Admin/modify_consumer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_consumer modify_consumer = db.modify_consumer.Find(id);
            if (modify_consumer == null)
            {
                return HttpNotFound();
            }
            return View(modify_consumer);
        }

        // GET: Admin/modify_consumer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/modify_consumer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "modify_consumerID,inword_no,modification_status,consumer_no,previous_name,previous_surname,previous_cnic,previous_mobile,previous_address,new_name,new_surname,new_cnic,new_mobile,new_address,createdby,createdon,description,approvedby,status")] modify_consumer modify_consumer)
        {
            if (ModelState.IsValid)
            {
                db.modify_consumer.Add(modify_consumer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(modify_consumer);
        }

        // GET: Admin/modify_consumer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_consumer modify_consumer = db.modify_consumer.Find(id);
            if (modify_consumer == null)
            {
                return HttpNotFound();
            }
            return View(modify_consumer);
        }

        // POST: Admin/modify_consumer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "modify_consumerID,inword_no,modification_status,consumer_no,previous_name,previous_surname,previous_cnic,previous_mobile,previous_address,new_name,new_surname,new_cnic,new_mobile,new_address,createdby,createdon,description,approvedby,status")] modify_consumer modify_consumer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(modify_consumer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(modify_consumer);
        }

        // GET: Admin/modify_consumer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            modify_consumer modify_consumer = db.modify_consumer.Find(id);
            if (modify_consumer == null)
            {
                return HttpNotFound();
            }
            return View(modify_consumer);
        }

        // POST: Admin/modify_consumer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            modify_consumer modify_consumer = db.modify_consumer.Find(id);
            db.modify_consumer.Remove(modify_consumer);
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
