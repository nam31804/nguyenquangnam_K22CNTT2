using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NguyenQuangNamK22CNTT2.Models;

namespace NguyenQuangNamK22CNTT2.Controllers
{
    public class hoasisController : Controller
    {
        private NguyenQuangNamK22CNTT2Entities db = new NguyenQuangNamK22CNTT2Entities();

        // GET: hoasis
        public ActionResult Index()
        {
            return View(db.hoasis.ToList());
        }

        // GET: hoasis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hoasi hoasi = db.hoasis.Find(id);
            if (hoasi == null)
            {
                return HttpNotFound();
            }
            return View(hoasi);
        }

        // GET: hoasis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hoasis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hoasi_id,hoasi_name,bio,website,ImagePath")] hoasi hoasi)
        {
            if (ModelState.IsValid)
            {
                db.hoasis.Add(hoasi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoasi);
        }

        // GET: hoasis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hoasi hoasi = db.hoasis.Find(id);
            if (hoasi == null)
            {
                return HttpNotFound();
            }
            return View(hoasi);
        }

        // POST: hoasis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hoasi_id,hoasi_name,bio,website,ImagePath")] hoasi hoasi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoasi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoasi);
        }

        // GET: hoasis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hoasi hoasi = db.hoasis.Find(id);
            if (hoasi == null)
            {
                return HttpNotFound();
            }
            return View(hoasi);
        }

        // POST: hoasis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hoasi hoasi = db.hoasis.Find(id);
            db.hoasis.Remove(hoasi);
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
