using MyWebsite.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.ViewModels
{
    public class DonHangVM
    {
        public int DonHangId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Time Order")]
        public DateTime ThoiGianDat { get; set; }
        [Required]
        [MaxLength(15)]
        [DisplayName("Phone Number")]
        public string? SDT { get; set; }
        [DisplayName("Note")]
        public string? Note { get; set; }
        [Required]
        [DisplayName("Address")]
        public string? DiaChiGiaoHang { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Status")]
        public string? TrangThai { get; set; }
        [Required]
        public string? NguoiDungId { get; set; }

        public List<SanPham>? SanPhams { get; set; }
    }  
}
