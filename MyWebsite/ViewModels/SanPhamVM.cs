using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MyWebsite.Models;

namespace MyWebsite.ViewModels
{
    public class SanPhamVM
    {
        public int? SanPhamID {  get; set; }
        [Required(ErrorMessage ="Product Name is required")]
        [DisplayName("Product Name")]
        public string? TenSanPham { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DisplayName("Price")]
        public int Gia { get; set; }

        [Required(ErrorMessage = "Discount is required")]
        [Range(0, 100)]
        [DisplayName("Discount")]
        public int GiamGia { get; set; }

        [Required(ErrorMessage = "Screen is required")]
        [DisplayName("Screen")]
        public float ManHinh { get; set; }

        [Required(ErrorMessage = "Camera is required")]
        [MaxLength(100)]
        [DisplayName("Camera")]
        public string? CameraSau { get; set; }

        [Required(ErrorMessage = "CameraSelfie is required")]
        [MaxLength(100)]
        [DisplayName("CameraSelfie")]
        public string? CameraSelfie { get; set; }

        [Required(ErrorMessage = "CPU is required")]
        [MaxLength(50)]
        public string? CPU { get; set; }

        [Required(ErrorMessage = "GPU is required")]
        [MaxLength(50)]
        public string? GPU { get; set; }

        [Required(ErrorMessage = "PIN is required")]
        public int PIN { get; set; }

        [Required(ErrorMessage = "RAM is required")]
        public int RAM { get; set; }

        [Required(ErrorMessage = "ROM is required")]
        public int ROM { get; set; }

        [Required(ErrorMessage = "OS is required")]
        [MaxLength(20)]
        [DisplayName("OS")]
        public string? HDH { get; set; }

        [Required(ErrorMessage = "Origin is required")]
        [MaxLength(30)]
        [DisplayName("Origin")]
        public string? XuatXu { get; set; }

        [DisplayName("Description")]
        public string? MoTa { get; set; }

        [Required(ErrorMessage = "Stock is required")]
        [DisplayName("Stock")]
        public int Kho { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [MaxLength(100)]
        [DisplayName("Image")]
        public string? HinhAnh { get; set; }
        

        public DanhMuc? DanhMuc { get; set; }
    }
}
