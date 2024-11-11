
using BaiTap.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BaiTap.Controllers
{
    public class QuanLyDonHangController : Controller
    {
        // GET: QuanLyDonHang
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DSDonHang()
        {
            List<DonHang> ds = db.DonHang.ToList();
            return View(ds);
        }
    }
}