using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models
{
    [Table("GioHang")]
    public class GioHang
    {
        [Key]
        public int GioHangId {  get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Min Value is 0")]
        public int SoLuong {  get; set; }
        public int? SanPhamId {  get; set; }
        [ForeignKey("SanPhamId")]
        public SanPham? SanPham { get; set; }
        [Required]
        public string? NguoiDungId {  get; set; }
    }
}
