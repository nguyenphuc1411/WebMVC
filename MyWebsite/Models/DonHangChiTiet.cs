using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models
{
    [Table("DonHangChiTiet")]
    public class DonHangChiTiet
    {
        [Key]
        public int ChiTietId {  get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Min Value is 0")]
        public int SoLuong {  get; set; }
        public int? SanPhamId {  get; set; }
        [ForeignKey("SanPhamId")]
        public SanPham? SanPham { get; set; }

        public int? DonHangId {  get; set; }
        [ForeignKey("DonHangId")]
        public DonHang? DonHang { get; set; }
    }
}
