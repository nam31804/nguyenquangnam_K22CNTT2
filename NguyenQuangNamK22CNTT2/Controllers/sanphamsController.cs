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
    public class sanphamsController : Controller
    {
        private NguyenQuangNamK22CNTT2Entities db = new NguyenQuangNamK22CNTT2Entities();

        // GET: sanphams
        public ActionResult Index()
        {
            var sanphams = db.sanphams.Include(s => s.hoasi);
            return View(sanphams.ToList());
        }

        // GET: sanphams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = db.sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // GET: sanphams/Create
        public ActionResult Create()
        {
            ViewBag.hoasi_id = new SelectList(db.hoasis, "hoasi_id", "hoasi_name");
            return View();
        }

        // POST: sanphams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "tranhve_id,hoasi_id,tieude,mota,gia,image_url")] sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.sanphams.Add(sanpham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hoasi_id = new SelectList(db.hoasis, "hoasi_id", "hoasi_name", sanpham.hoasi_id);
            return View(sanpham);
        }

        // GET: sanphams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = db.sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            ViewBag.hoasi_id = new SelectList(db.hoasis, "hoasi_id", "hoasi_name", sanpham.hoasi_id);
            return View(sanpham);
        }

        // POST: sanphams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "tranhve_id,hoasi_id,tieude,mota,gia,image_url")] sanpham sanpham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sanpham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hoasi_id = new SelectList(db.hoasis, "hoasi_id", "hoasi_name", sanpham.hoasi_id);
            return View(sanpham);
        }

        // GET: sanphams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sanpham sanpham = db.sanphams.Find(id);
            if (sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }

        // POST: sanphams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sanpham sanpham = db.sanphams.Find(id);
            db.sanphams.Remove(sanpham);
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
