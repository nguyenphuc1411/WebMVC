using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Data;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System.Net.WebSockets;

namespace MyWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class NguoiDungController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> userManager;

        public NguoiDungController(AppDbContext context,UserManager<AppUser> _userManager)
        {
            _context = context;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index(string search)
        {
            var users = await userManager.Users.Select(u => new UserVM
            {
                ID = u.Id,
                Name = u.Name,
                PhoneNumber = u.PhoneNumber,
                Address = u.Address,
                Email = u.Email,
                ImageUser = u.ImageUser,
                CreatedDate = u.CreatedDate
            }).ToListAsync();
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                users.Where(x=>x.Name!.Contains(search)).ToList();
                return View(users);
            }
            return View(users);
        }

    }
}
