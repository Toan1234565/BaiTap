namespace BaiTap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BaoCao")]
    public partial class BaoCao
    {
        [Key]
        public int BCID { get; set; }
        [DisplayName("Ngày báo cáo")]
        [Column(TypeName = "date")]
        public DateTime? NgayBaoCao { get; set; }
        [DisplayName("Doanh số ")]
        public double DanhSo { get; set; }
        [DisplayName("Tổng đơn hàng bán thanh công")]
        public int TongDonHang { get; set; }
        [DisplayName("Ngày cập nhât")]
        [Column(TypeName = "date")]
        public DateTime? NgayCapNhatCC { get; set; }
    }
}
