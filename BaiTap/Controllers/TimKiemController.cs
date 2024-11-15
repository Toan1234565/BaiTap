<<<<<<< HEAD
﻿
=======
﻿using BaiTap.Models;
>>>>>>> cf20b19c201406323190693f59e183afae7e4007
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
<<<<<<< HEAD
using BaiTap.Models;
=======

>>>>>>> cf20b19c201406323190693f59e183afae7e4007
namespace BaiTap.Controllers
{
    public class TimKiemController : Controller
    {
        private Model1 db = new Model1();
        // GET: TimKiem
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TimKiem(string name)
        {
            var kq = db.SanPham.Where(sp=> sp.TenSanPham.Contains(name) || sp.MoTa.Contains(name)).ToList();
            return View(kq);
        }
        public ActionResult LocSP(string name, int ? IDHang, int ? IDDanhMuc,double ? to, double ? from, string sx)
        {
            var kq = from sp in db.SanPham select sp;
            if(IDDanhMuc.HasValue && IDDanhMuc != 0)
            {
                kq = kq.Where(sp => sp.DanhMucID == IDDanhMuc.Value);
            }
            if(IDHang.HasValue && IDHang != 0)
            {
                kq = kq.Where(sp => sp.HangID == IDHang.Value); 
            }
            if(from != 0 && to != 0)
            {
                kq = kq.Where(x => x.Gia >= from && x.Gia <= to);
            }
            switch (sx)
            {
                case "Giatang":
                    kq = kq.OrderBy(x => x.Gia);break;
                case "Giagiam":
                    kq = kq.OrderByDescending(x => x.Gia);break;
                default:
                    kq.OrderBy(x => x.Gia);
                    break;
            }
            return View(kq.ToList());

        }
    }
}