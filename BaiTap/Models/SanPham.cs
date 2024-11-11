namespace BaiTap.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            ChiTietSanPham = new HashSet<ChiTietSanPham>();
            SanPhamKhuyenMai = new HashSet<SanPhamKhuyenMai>();
            Sosanh = new HashSet<Sosanh>();
            Sosanh1 = new HashSet<Sosanh>();
            TonKho = new HashSet<TonKho>();
        }

        public int SanPhamID { get; set; }
        [DisplayName("Tên sản phẩm")]
        [StringLength(100)]
        public string TenSanPham { get; set; }
        [DisplayName("Số lượng ")]
        public int? Soluong { get; set; }
        [DisplayName("Mô tả")]
        [StringLength(500)]
        public string MoTa { get; set; }
        [DisplayName("Giá")]
        public double? Gia { get; set; }
        [DisplayName("Danh mục ")]
        public int? DanhMucID { get; set; }
        [DisplayName("Hãng sản xuất")]
        public int? HangID { get; set; }
        [DisplayName("Hình ảnh")]
        [StringLength(200)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPham { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        public virtual Hang Hang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SanPhamKhuyenMai> SanPhamKhuyenMai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sosanh> Sosanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sosanh> Sosanh1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TonKho> TonKho { get; set; }
    }
}
