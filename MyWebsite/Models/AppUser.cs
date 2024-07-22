using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace MyWebsite.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        [StringLength(100)]
        [MaxLength(100)]
        public string? Name {  get; set; }

        [Required]
        public string? Address {  get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }

        public string? ImageUser {  get; set; }
    }
}
