
using BaiTap.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace BaiTap.Controllers
{
    [RoutePrefix("api/QuanLySanPham")]
    public class QuanLySanPhamController : Controller
    {
        // GET: QuanLySanPham
        
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult GetSanPham()
        //{
        //    var sp = db.SanPham.ToList();
        //    return Json(sp, JsonRequestBehavior.AllowGet);
        //}
        //[HttpGet]
        public ActionResult SanPham()
        {
            List<SanPham> ds = db.SanPham.ToList(); 
            return View(ds);
        }
        // cho phep cua sua san pham
        public ActionResult Sua(int id)
        { 
            var sp = db.SanPham.Find(id);
            return View(sp);
        }
        [HttpPost]
        public ActionResult Sua(SanPham sanpham)
        {
            if (string.IsNullOrEmpty(sanpham.TenSanPham) == true)
            {
                ModelState.AddModelError("", "Ten san pham ko dc d trong");
                return View(sanpham);
            }
            if (sanpham.Soluong < 0)
            {
                ModelState.AddModelError("", "So luong ko nho hon 0");
                return View(sanpham);
            }
            if (sanpham.Gia < 0)
            {
                ModelState.AddModelError("", "gia ko nho hon 0");
                return View(sanpham);

            }
            var update = db.SanPham.Find(sanpham.SanPhamID);
            update.TenSanPham = sanpham.TenSanPham;
            update.Soluong = sanpham.Soluong;
            update.MoTa = sanpham.MoTa;
            update.HangID = sanpham.HangID;
            update.DanhMucID = sanpham.DanhMucID;
            update.HinhAnh = sanpham.HinhAnh;
            update.SanPhamKhuyenMai = sanpham.SanPhamKhuyenMai;
            var id = db.SaveChanges();
            if (id > 0)
            {
                return RedirectToAction("SanPham");
            }
            else
            {
                ModelState.AddModelError("", "thay doi thong tin san pham that bai ");
                return View(db);
            }


        }
        // xoa cac san pham khong can thiet va xoa luon ca trong ca o kho hang 
        [HttpGet]
        public ActionResult Xoa(int id)
        {
            var sanpham = db.SanPham.Find(id);
            if(sanpham == null)
            {
                return HttpNotFound();
            }
            return View(sanpham);
        }
        [HttpPost, ActionName("Xoa")]
        public ActionResult xacnhan(int id)
        {
            var sp = db.SanPham.Find(id);
            if(sp == null)
            {
                return HttpNotFound();
            }
            var sanpham = db.ChiTietSanPham.Where(x => x.SanPhamID == id).ToList();
            db.SanPham.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("sanpham");
             
        }   


        // hien thi tat ca chi tiet cua cac san pham co trong ..
        public ActionResult DSChiTiet()
        {
            List<ChiTietSanPham> ds = db.ChiTietSanPham.ToList();
            return View(ds);
        }
        // khi an xem chi tiet cua mot san pham thi hien ra thoong tin chi tiet san pham do len man hinh 
        public ActionResult XemChiTiet(int id)
        {
            var chiTietSanPham = db.ChiTietSanPham.Where(c => c.SanPhamID == id).ToList();
            if (chiTietSanPham == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSanPham);
           
        }
        public ActionResult Index11()
        {
            return View();
        }
















        [HttpGet]
        public ActionResult ThemSanPham()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham(SanPham sp)
        {
            if(string.IsNullOrEmpty(sp.TenSanPham))
            {
                ModelState.AddModelError("", "Ten san pham khong duoc de trong");
            }
            if(sp.Gia < 0)
            {
                ModelState.AddModelError("", "Gia san pham khong duoc nho hon 0");
            }
            if(sp.Soluong < 0)
            {
                ModelState.AddModelError("", "So luong phai lon hon 0");
            }
            db.SanPham.Add(sp);
            db.SaveChanges();
            return View("ThemChiTiet", new {id = sp.SanPhamID});
        }
        [HttpGet]
        public ActionResult ThemChiTiet(int id)
        {
            var sp = db.SanPham.Find(id);
            if(sp == null)
            {
                return HttpNotFound();
            }
            ViewBag.SanPhan = sp;
            return View(new ChiTietSanPham { SanPhamID = sp.SanPhamID});
        }
        [HttpPost]
        public ActionResult ThemChiTiet(ChiTietSanPham chitiet)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try { 
                var sp = db.SanPham.Find(chitiet.SanPhamID);
                if (sp == null)
                {
                    ModelState.AddModelError("", "that bai");
                    return View(chitiet);
                }
                db.ChiTietSanPham.Add(chitiet);
                db.SaveChanges();
                transaction.Commit();
                return View("danhsach");
                } catch (Exception ex)
                {
                    transaction.Rollback();
                    ModelState.AddModelError("", "Có lỗi xảy ra: " + ex.Message);
                    return View(chitiet);
                }
            }

        }
        
        //public ActionResult DSChiTiet(int id)
        //{
        //    var sanpham = db.SanPham.Include("ChiTietSanPham").FirstOrDefault(sp => sp.SanPhamID == id);
        //    return PartialView("DSChiTiet",sanpham);
            
        //}

    }
}