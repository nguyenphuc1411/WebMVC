using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models
{
    [Table("DanhGia")]
    public class DanhGia
    {
        [Key]
        public int DanhGiaId { get; set;}
        [Required]
        public int SoSao {  get; set;}
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime ThoiGian { get; set;}
        public string? NoiDung {  get; set;}
        [Required]
        public string? NguoiDungId {  get; set;}
        public int? SanPhamId {  get; set;}
        [ForeignKey("SanPhamId")]
        public SanPham? SanPham { get; set;}
    }
}
