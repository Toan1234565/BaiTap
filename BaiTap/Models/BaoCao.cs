<<<<<<< HEAD
namespace BaiTap.Models
{
    using System;
    using System.Collections.Generic;
=======
﻿namespace BaiTap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
>>>>>>> cf20b19c201406323190693f59e183afae7e4007
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoCao")]
    public partial class BaoCao
    {
        [Key]
        public int BCID { get; set; }
<<<<<<< HEAD

        [Column(TypeName = "date")]
        public DateTime? NgayBaoCao { get; set; }

        public double DanhSo { get; set; }

        public int TongDonHang { get; set; }

=======
        [DisplayName("Ngày báo cáo")]
        [Column(TypeName = "date")]
        public DateTime? NgayBaoCao { get; set; }
        [DisplayName("Doanh số ")]
        public double DanhSo { get; set; }
        [DisplayName("Tổng đơn hàng bán thanh công")]
        public int TongDonHang { get; set; }
        [DisplayName("Ngày cập nhât")]
>>>>>>> cf20b19c201406323190693f59e183afae7e4007
        [Column(TypeName = "date")]
        public DateTime? NgayCapNhatCC { get; set; }
    }
}
