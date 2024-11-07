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
    public class khachhangsController : Controller
    {
        private NguyenQuangNamK22CNTT2Entities db = new NguyenQuangNamK22CNTT2Entities();

        // GET: khachhangs
        public ActionResult Index()
        {
            return View(db.khachhangs.ToList());
        }

        // GET: khachhangs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khachhang khachhang = db.khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // GET: khachhangs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: khachhangs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "khachhang_id,khachhang_name,email,taikhoan,matkhau,ngaysinh,diachi,SDT,img")] khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.khachhangs.Add(khachhang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachhang);
        }

        // GET: khachhangs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khachhang khachhang = db.khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: khachhangs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "khachhang_id,khachhang_name,email,taikhoan,matkhau,ngaysinh,diachi,SDT,img")] khachhang khachhang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachhang).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachhang);
        }

        // GET: khachhangs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            khachhang khachhang = db.khachhangs.Find(id);
            if (khachhang == null)
            {
                return HttpNotFound();
            }
            return View(khachhang);
        }

        // POST: khachhangs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            khachhang khachhang = db.khachhangs.Find(id);
            db.khachhangs.Remove(khachhang);
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
        public ActionResult Login()
        {
            return View();
        }

        // POST: khachhangs/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra tài khoản và mật khẩu
                var user = db.khachhangs.FirstOrDefault(k => k.taikhoan == model.Taikhoan && k.matkhau == model.Matkhau);
                if (user != null)
                {
                    // Lưu thông tin vào Session
                    Session["UserId"] = user.khachhang_id;
                    Session["Username"] = user.khachhang_name;

                    // Chuyển hướng đến trang Welcome
                    return RedirectToAction("Welcome");
                }
                else
                {
                    // Nếu tài khoản hoặc mật khẩu sai, thêm lỗi vào ModelState
                    ModelState.AddModelError("", "Tên tài khoản hoặc mật khẩu không đúng.");
                }
            }
            return View(model);
        }

        // GET: khachhangs/Welcome
        public ActionResult Welcome()
        {
            // Kiểm tra nếu người dùng chưa đăng nhập
            if (Session["UserId"] == null)
            {
                return RedirectToAction("Login");
            }

            // Lấy tên người dùng từ session và hiển thị
            ViewBag.Username = Session["Username"];
            return View();
        }

        // GET: khachhangs/Logout
        public ActionResult Logout()
        {
            // Xóa thông tin đăng nhập trong session
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

