using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models
{
    [Table("SanPham")]
    public class SanPham
    {
        [Key]
        public int SanPhamId {  get; set; }
        [Required(ErrorMessage ="Product Name is required")]
        [MaxLength(200)]
        [DisplayName("Product Name")]
        public string? TenSanPham { get; set; }
        [Required]
        [DisplayName("Price")]
        [Range(1,int.MaxValue,ErrorMessage ="Min Value is 1")]
        public int Gia {  get; set; }
        [Required]
        [Range(0, 100)]
        [DisplayName("Discount")]
        public int GiamGia {  get; set; }
        [Required]
        [DisplayName("Screen")]
        [Range(0, int.MaxValue, ErrorMessage = "Min Value is 0")]
        public float ManHinh {  get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Camera")]
        public string? CameraSau {  get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("CameraSelfie")]
        public string? CameraSelfie {  get; set; }
        [Required]
        [MaxLength(50)]
        public string? CPU {  get; set; }
        [Required]
        [MaxLength(50)]
        public string? GPU {  get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Min Value is 0")]
        public int PIN {  get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Min Value is 0")]
        public int RAM {  get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Min Value is 0")]
        public int ROM {  get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("OS")]
        public string? HDH {  get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Origin")]
        public string? XuatXu {  get; set; }
        [Required]
        [DisplayName("Description")]
        public string? MoTa {  get; set; }
        [Required]
        [DisplayName("Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "Min Value is 0")]
        public int Kho {  get; set; }
        [Required]
        [MaxLength(100)]
        [DisplayName("Image")]
        public string? HinhAnh {  get; set; }
        [DisplayName("CategoryID")]
        public int? DanhMucId {  get; set; }
        [ForeignKey("DanhMucId")]
        public DanhMuc? DanhMuc { get; set; }

        public virtual ICollection<GioHang>? GioHangs { get; set; }

        public virtual ICollection<DonHangChiTiet>? DonHangChiTiets { get; set; }

        public virtual ICollection<DanhGia>? DanhGias { get; set; }
    }
}
