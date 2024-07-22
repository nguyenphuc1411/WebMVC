using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebsite.Models
{
    [Table("DanhMuc")]
    public class DanhMuc
    {
        [Key]
        public int DanhMucId { get; set; }
        [Required]
        [StringLength(50)]
        [MaxLength(50)]
        [DisplayName("Category Name")]
        public string? TenDanhMuc {  get; set; }
        [Required]
        [StringLength (255)]
        [MaxLength (255)]
        [DisplayName("Image")]
        public string? HinhAnh {  get; set; }
        [Required]
        [DisplayName("Status")]
        public bool TrangThai {  get; set; }

        public virtual ICollection<SanPham>? SanPhams { get; set; }
    }
}
