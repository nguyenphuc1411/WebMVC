using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Data;
using MyWebsite.Models;

namespace MyWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DonHangController : Controller
    {
        
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public DonHangController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userID = _userManager.GetUserId(User);
            var userDN = await _userManager.FindByIdAsync(userID!);

            if (userDN != null)
            {
                var listDonHang = _context.DonHangs.ToList();
                return View(listDonHang);
            }

            else
            {
                // Xử lý khi không tìm thấy người dùng
                return NotFound(); // hoặc thực hiện một hành động khác tùy thuộc vào yêu cầu của bạn
            }
        }
    }
}
