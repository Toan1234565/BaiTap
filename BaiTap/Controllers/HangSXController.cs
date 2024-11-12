<<<<<<< HEAD
﻿
using BaiTap.Models;
=======
﻿using BaiTap.Models;
>>>>>>> cf20b19c201406323190693f59e183afae7e4007
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap.Controllers
{
    public class HangSXController : Controller
    {
        private Model1 db = new Model1();
        // GET: HangSX
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DSHangsx()
        {
            List<Hang> ds = db.Hang.ToList();
            return View(ds);
        }
    }
}