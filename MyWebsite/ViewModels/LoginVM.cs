using System.ComponentModel.DataAnnotations;

namespace MyWebsite.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Username là required")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Password là required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
