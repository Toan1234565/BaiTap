<<<<<<< HEAD
﻿
using System;
using BaiTap.Models;
=======
﻿using BaiTap.Models;
using System;
>>>>>>> cf20b19c201406323190693f59e183afae7e4007
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DsDanhMuc()
        {
            List<DanhMuc> ds = db.DanhMuc.ToList();
            return View(ds);
        }
    }
}