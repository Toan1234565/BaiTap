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
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(Admins admins)
        {
            return View();
        }
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(Admins admins)
        {
            return View();
        }
    }
}