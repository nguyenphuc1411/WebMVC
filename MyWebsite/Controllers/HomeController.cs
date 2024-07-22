using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Data;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System.Diagnostics;

namespace MyWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly AppDbContext _context;      
        public HomeController(ILogger<HomeController> logger, AppDbContext context, UserManager<AppUser> userManager)
        {
            _userManager = userManager;
            _context = context;
            _logger = logger;

        }

        [HttpGet]
        public async Task<IActionResult> Index(int? DanhMucId, string name, int? loc, int? priceMin, int? priceMax, int? pinMin, int? pinMax)
        {
            ViewBag.DanhMuc = await _context.DanhMucs.Where(x => x.TrangThai == true).ToListAsync();
            ViewBag.DanhMucHienTai = DanhMucId;
            ViewBag.BoLoc = new BoLocVM
            {
                priceMin = priceMin,
                priceMax = priceMax,
                pinMin = pinMin,
                pinMax = pinMax
            };
            List<SanPham> listSP = await _context.SanPhams.ToListAsync();

            // Xử lý tìm kiếm theo tên
            if (!string.IsNullOrEmpty(name))
            {
                return View(listSP.Where(x => x.TenSanPham!.Contains(name)).ToList());
            }

            // Xử lý lọc theo danh mục
            if (DanhMucId != null)
            {
                var listSPTheoDM = listSP.Where(x => x.DanhMucId == DanhMucId).ToList();

                // Xử lý lọc theo tiêu chí
                if (loc != null)
                {
                    switch (loc)
                    {
                        case 1:
                            return View(listSPTheoDM.OrderBy(x => x.Gia).ToList());
                        case 2:
                            return View(listSPTheoDM.OrderByDescending(x => x.Gia).ToList());
                        case 3:
                            return View(listSPTheoDM.OrderBy(x => x.TenSanPham).ToList());
                        case 4:
                            return View(listSPTheoDM.OrderByDescending(x => x.TenSanPham).ToList());
                    }
                }

                // Xử lý lọc theo giá và PIN
                if (priceMin != null || priceMax != null || pinMin != null || pinMax != null)
                {
                    var listSP_Price = listSPTheoDM.ToList();

                    if (priceMin != null)
                    {
                        if (priceMax != null)
                        {
                            listSP_Price = listSP_Price.Where(x => x.Gia >= priceMin && x.Gia <= priceMax).ToList();
                        }
                        else
                        {
                            listSP_Price = listSP_Price.Where(x => x.Gia >= priceMin).ToList();
                        }
                    }
                    else if (priceMax != null)
                    {
                        listSP_Price = listSP_Price.Where(x => x.Gia <= priceMax).ToList();
                    }

                    if (pinMin != null)
                    {
                        if (pinMax != null)
                        {
                            listSP_Price = listSP_Price.Where(x => x.PIN >= pinMin && x.PIN <= pinMax).ToList();
                        }
                        else
                        {
                            listSP_Price = listSP_Price.Where(x => x.PIN >= pinMin).ToList();
                        }
                    }
                    else if (pinMax != null)
                    {
                        listSP_Price = listSP_Price.Where(x => x.PIN <= pinMax).ToList();
                    }

                    return View(listSP_Price);
                }

                // Trả về danh sách sản phẩm theo danh mục
                return View(listSPTheoDM);
            }
            else
            {
                // Xử lý lọc theo tiêu chí nếu không có danh mục
                if (loc != null)
                {
                    switch (loc)
                    {
                        case 1:
                            return View(listSP.OrderBy(x => x.Gia).ToList());
                        case 2:
                            return View(listSP.OrderByDescending(x => x.Gia).ToList());
                        case 3:
                            return View(listSP.OrderBy(x => x.TenSanPham).ToList());
                        case 4:
                            return View(listSP.OrderByDescending(x => x.TenSanPham).ToList());
                    }
                }

                // Xử lý lọc theo giá và PIN nếu không có danh mục
                if (priceMin != null || priceMax != null || pinMin != null || pinMax != null)
                {
                    var listSP_Price = listSP.ToList();

                    if (priceMin != null)
                    {
                        if (priceMax != null)
                        {
                            listSP_Price = listSP_Price.Where(x => x.Gia >= priceMin && x.Gia <= priceMax).ToList();
                        }
                        else
                        {
                            listSP_Price = listSP_Price.Where(x => x.Gia >= priceMin).ToList();
                        }
                    }
                    else if (priceMax != null)
                    {
                        listSP_Price = listSP_Price.Where(x => x.Gia <= priceMax).ToList();
                    }

                    if (pinMin != null)
                    {
                        if (pinMax != null)
                        {
                            listSP_Price = listSP_Price.Where(x => x.PIN >= pinMin && x.PIN <= pinMax).ToList();
                        }
                        else
                        {
                            listSP_Price = listSP_Price.Where(x => x.PIN >= pinMin).ToList();
                        }
                    }
                    else if (pinMax != null)
                    {
                        listSP_Price = listSP_Price.Where(x => x.PIN <= pinMax).ToList();
                    }

                    return View(listSP_Price);
                }

                // Trả về danh sách sản phẩm không lọc
                return View(listSP);
            }
        }

        public IActionResult Detail(int? id)
        {
            ViewBag.DanhGia = _context.DanhGias.Where(x=>x.SanPhamId==id).ToList();
            var sanPham = _context.SanPhams.FirstOrDefault(sp => sp.SanPhamId == id);
            return View(sanPham);
        }


        public IActionResult Contact()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public async Task<IActionResult> Detail(int SanPhamId, int SoSao, string Comment)
        {
            var userID = _userManager.GetUserId(User);
            var userDN = await _userManager.FindByIdAsync(userID!); 

            if (userDN == null)
            {
                return RedirectToAction("Login", "Account");
            }

            DanhGia danhGia = new DanhGia()
            {
                SoSao = SoSao,
                NoiDung = Comment,
                ThoiGian = DateTime.Now,
                SanPhamId = SanPhamId,
                NguoiDungId = userID
            };

            _context.DanhGias.Add(danhGia); 
            await _context.SaveChangesAsync(); 
            ViewBag.DanhGia = _context.DanhGias.Where(x=>x.SanPhamId==SanPhamId).ToList();
            return RedirectToAction("Detail", "Home", new { SanPhamId = SanPhamId }); 
        }

    }
}
