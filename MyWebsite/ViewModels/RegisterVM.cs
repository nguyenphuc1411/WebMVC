using System.ComponentModel.DataAnnotations;

namespace MyWebsite.ViewModels
{
    public class RegisterVM
    {
        [Required(ErrorMessage ="Tên là bắt buộc")]
        public string? Name {  get; set; }
        [Required(ErrorMessage = "Username là bắt buộc")]
        [MaxLength(20)]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Email là bắt buộc")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Mật khẩu là bắt buộc")]
        [DataType(DataType.Password)]
        public string? Password {  get; set; }
        [Compare("Password",ErrorMessage ="Mật khẩu không khớp")]
        public string? ConfirmPassword {  get; set; }
    }
}
