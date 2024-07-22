using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int DonHangId { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Time Order")]
        public DateTime ThoiGianDat { get; set; }
        [Required]
        [MaxLength(15)]
        [DisplayName("Phone Number")]
        public string? SDT {  get; set; }
        [DisplayName("Note")]
        public string? Note {  get; set; }
        [Required]
        [DisplayName("Address")]
        public string? DiaChiGiaoHang {  get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Status")]
        public string? TrangThai {  get; set; }
        [Required]
        public string? NguoiDungId {  get; set; }
        
        public virtual ICollection<DonHangChiTiet>? DonHangChiTiets { get; set; }
    }
}
