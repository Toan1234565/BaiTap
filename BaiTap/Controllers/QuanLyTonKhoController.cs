﻿
using BaiTap.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace BaiTap.Controllers
{
    public class QuanLyTonKhoController : Controller
    {
        private Model1 db = new Model1();
        // GET: QuanLyTonKho
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SanPhamTonKho()
        {
            List<TonKho> ds = db.TonKho.ToList();
            
              return View(ds);
        }

        public ActionResult Nhap() {
            return View(new PhieuNhapKhoViewModel()); 
        }
        public ActionResult Kiemtra()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult KiemTra(PhieuNhapKhoViewModel model)
        {
            if (model.SanPhamID.HasValue)
            {
                var sanpham = db.SanPham.Find(model.SanPhamID.Value);
                if (sanpham != null)
                {
                    return RedirectToAction("NhapSanPhamCoSan", new { id = model.SanPhamID.Value });
                }
            }
            return RedirectToAction("NhapKho");
        }



            public ActionResult NhapSanPhamCoSan(int id)
            {
                var sanPham = db.SanPham.Find(id);
            if (sanPham != null)
            {
                var viewModel = new PhieuNhapKhoViewModel
                {
                    SanPhamID = sanPham.SanPhamID,
                    soluong = 0,
                    

                };
                return View(viewModel);
            }
            return HttpNotFound();
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult NhapSanPhamCoSan(PhieuNhapKhoViewModel model)
            {
                if (ModelState.IsValid)
                {
                    var sp = db.SanPham.FirstOrDefault(p => p.SanPhamID == model.SanPhamID);
                    var sp1 = db.TonKho.FirstOrDefault(p => p.SanPhamID == model.SanPhamID);
                    if (sp != null && sp1 != null)
                    {
                        sp.Soluong += model.soluong;
                        sp.Gia = model.Gia;
                        sp1.SoLuongTon += model.soluong;
                        db.SaveChanges();
                        return RedirectToAction("SanPhamTonKho");
                    }
                }
                return View(model);
            }



      
        public ActionResult NhapKho()
        {
            var viewmodel = new PhieuNhapKhoViewModel
            {
                SanPham = new SanPham(),
                ChiTietSanPham = new ChiTietSanPham(),
                TonKho = new TonKho()
            };
            return View(viewmodel);
            //return View(new PhieuNhapKhoViewModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NhapKho(PhieuNhapKhoViewModel model)
        {
            if(ModelState.IsValid)
            { 
                    if (!string.IsNullOrEmpty(model.DanhMucMoi))
                    {
                        var danhmuc = db.DanhMuc.FirstOrDefault(dm => dm.TenDanhMuc == model.DanhMucMoi);
                        if (danhmuc == null)
                        {
                            danhmuc = new DanhMuc { TenDanhMuc = model.DanhMucMoi };
                            db.DanhMuc.Add(danhmuc);
                            db.SaveChanges();
                        }
                        model.SanPham.DanhMucID = danhmuc.DanhMucID;
                    }
                    if (!string.IsNullOrEmpty(model.HangsxMoi))
                    {
                        var hang = db.Hang.FirstOrDefault(h => h.TenHang == model.HangsxMoi);
                        if (hang == null)
                        {
                            hang = new Hang { TenHang = model.HangsxMoi };
                            db.Hang.Add(hang);
                            db.SaveChanges();
                        }
                    }
                        var sanpham = model.SanPham;
                        db.SanPham.Add(sanpham);
                        db.SaveChanges();

                        var ChiTiet = model.ChiTietSanPham;
                        model.ChiTietSanPham.SanPhamID = model.SanPham.SanPhamID;
                        db.ChiTietSanPham.Add(ChiTiet);
                        db.SaveChanges();

                        model.TonKho.SanPhamID = model.SanPham.SanPhamID;
                        model.TonKho.NgayCapNhat = DateTime.Now;
                        db.TonKho.Add(model.TonKho);
                        db.SaveChanges();
                        return RedirectToAction("SanPhamTonKho");

            }
            return View(model);
        }
      

        public ActionResult XuatKho()
        {
            return View();
        }
        
        
        public ActionResult Sapxep()
        {
            return View();
        }
    }
}