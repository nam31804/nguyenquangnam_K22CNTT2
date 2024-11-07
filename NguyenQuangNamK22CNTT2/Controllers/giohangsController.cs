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
    public class giohangsController : Controller
    {
        private NguyenQuangNamK22CNTT2Entities db = new NguyenQuangNamK22CNTT2Entities();

        // GET: giohangs
        public ActionResult Index()
        {
            var giohangs = db.giohangs.Include(g => g.khachhang).Include(g => g.sanpham);
            return View(giohangs.ToList());
        }

        // GET: giohangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giohang giohang = db.giohangs.Find(id);
            if (giohang == null)
            {
                return HttpNotFound();
            }
            return View(giohang);
        }

        // GET: giohangs/Create
        public ActionResult Create()
        {
            ViewBag.khachhang_id = new SelectList(db.khachhangs, "khachhang_id", "khachhang_name");
            ViewBag.tranhve_id = new SelectList(db.sanphams, "tranhve_id", "tieude");
            return View();
        }

        // POST: giohangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "giohang_id,khachhang_id,tranhve_id,soluong")] giohang giohang)
        {
            if (ModelState.IsValid)
            {
                db.giohangs.Add(giohang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.khachhang_id = new SelectList(db.khachhangs, "khachhang_id", "khachhang_name", giohang.khachhang_id);
            ViewBag.tranhve_id = new SelectList(db.sanphams, "tranhve_id", "tieude", giohang.tranhve_id);
            return View(giohang);
        }

        // GET: giohangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giohang giohang = db.giohangs.Find(id);
            if (giohang == null)
            {
                return HttpNotFound();
            }
            ViewBag.khachhang_id = new SelectList(db.khachhangs, "khachhang_id", "khachhang_name", giohang.khachhang_id);
            ViewBag.tranhve_id = new SelectList(db.sanphams, "tranhve_id", "tieude", giohang.tranhve_id);
            return View(giohang);
        }

        // POST: giohangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "giohang_id,khachhang_id,tranhve_id,soluong")] giohang giohang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giohang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.khachhang_id = new SelectList(db.khachhangs, "khachhang_id", "khachhang_name", giohang.khachhang_id);
            ViewBag.tranhve_id = new SelectList(db.sanphams, "tranhve_id", "tieude", giohang.tranhve_id);
            return View(giohang);
        }

        // GET: giohangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            giohang giohang = db.giohangs.Find(id);
            if (giohang == null)
            {
                return HttpNotFound();
            }
            return View(giohang);
        }

        // POST: giohangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            giohang giohang = db.giohangs.Find(id);
            db.giohangs.Remove(giohang);
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
