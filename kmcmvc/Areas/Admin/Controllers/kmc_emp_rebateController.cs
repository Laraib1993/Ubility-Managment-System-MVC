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
    public class kmc_emp_rebateController : Controller
    {
        private AdminEntities db = new AdminEntities();

        // GET: Admin/kmc_emp_rebate
        public ActionResult Index()
        {
            return View(db.kmc_emp_rebate.ToList());
        }

        // GET: Admin/kmc_emp_rebate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kmc_emp_rebate kmc_emp_rebate = db.kmc_emp_rebate.Find(id);
            if (kmc_emp_rebate == null)
            {
                return HttpNotFound();
            }
            return View(kmc_emp_rebate);
        }

        // GET: Admin/kmc_emp_rebate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/kmc_emp_rebate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sno,inword,consumer_no,emp_id,consumer_name,consumer_fname,consumer_cnic,consumer_mobile,consumer_address,category,area,outstanding_Arrears,after_rebate,description,createdby,createdon,status")] kmc_emp_rebate kmc_emp_rebate)
        {
            if (ModelState.IsValid)
            {
                db.kmc_emp_rebate.Add(kmc_emp_rebate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kmc_emp_rebate);
        }

        // GET: Admin/kmc_emp_rebate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kmc_emp_rebate kmc_emp_rebate = db.kmc_emp_rebate.Find(id);
            if (kmc_emp_rebate == null)
            {
                return HttpNotFound();
            }
            return View(kmc_emp_rebate);
        }

        // POST: Admin/kmc_emp_rebate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sno,inword,consumer_no,emp_id,consumer_name,consumer_fname,consumer_cnic,consumer_mobile,consumer_address,category,area,outstanding_Arrears,after_rebate,description,createdby,createdon,status")] kmc_emp_rebate kmc_emp_rebate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kmc_emp_rebate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kmc_emp_rebate);
        }

        // GET: Admin/kmc_emp_rebate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kmc_emp_rebate kmc_emp_rebate = db.kmc_emp_rebate.Find(id);
            if (kmc_emp_rebate == null)
            {
                return HttpNotFound();
            }
            return View(kmc_emp_rebate);
        }

        // POST: Admin/kmc_emp_rebate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kmc_emp_rebate kmc_emp_rebate = db.kmc_emp_rebate.Find(id);
            db.kmc_emp_rebate.Remove(kmc_emp_rebate);
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
