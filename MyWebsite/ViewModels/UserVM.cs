using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.ViewModels
{
    public class UserVM
    {
        public string? ID {  get; set; }
        [Required]
        [StringLength(100)]
        [MaxLength(100)]
        public string? Name { get; set; }
        [Required]
        public string? Address { get; set; }
        [MaxLength(15)]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email {  get; set; }
        public string ? Password { get; set; }
        public string? NewPassword {  get; set; }
        public string? ImageUser { get; set; }
    }
}
