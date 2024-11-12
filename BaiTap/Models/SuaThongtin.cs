using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BaiTap.Models
{
    public class SuaThongtin
    {
        public int? SanPhamID { get; set; }
        public SanPham SanPham { get; set; }
        public ChiTietSanPham ChiTietSanPham { get; set; }
        public TonKho TonKho { get; set; }
    }
}