using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Data;
using MyWebsite.Models;
using MyWebsite.ViewModels;

namespace MyWebsite.Controllers
{
    public class ThanhToanController : Controller
    {
        private readonly AppDbContext _context;
        public ThanhToanController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<GioHangVM> carts = SessionHelper.GetObjectFromJson<List<GioHangVM>>(HttpContext.Session, "cart");
            if (carts != null)
            {               
                ViewBag.Total = carts.Sum(x => x.SoLuong * x.SanPham!.Gia);
                return View(carts);
            }
            return View();
        }
        public IActionResult DatHang(string NguoiDungId,string diaChiGiaoHang,string sdt,string note)
        {
            if (NguoiDungId != null && diaChiGiaoHang != null&&sdt!=null && note!=null)
            {
                DonHang donhang = new DonHang
                {
                    ThoiGianDat = DateTime.Now,
                    SDT = sdt,
                    Note = note,
                    DiaChiGiaoHang = diaChiGiaoHang,
                    TrangThai = "VuaDatHang",
                    NguoiDungId = NguoiDungId
                };

                var result = _context.DonHangs.Add(donhang);
                _context.SaveChanges();
                if (result != null)
                {
                    List<GioHangVM> carts = SessionHelper.GetObjectFromJson<List<GioHangVM>>(HttpContext.Session, "cart");
                    if (carts != null)
                    {
                        foreach (var item in carts)
                        {
                            _context.DonHangChiTiets.Add(new DonHangChiTiet
                            {
                                SoLuong = item.SoLuong,
                                SanPhamId = item.SanPham!.SanPhamId,
                                DonHangId = result.Entity.DonHangId
                            });
                            _context.SaveChanges();
                        }
                        return RedirectToAction("Index", "DonHang");
                    }
                }
            }
            return RedirectToAction("Index", "Home");
        }
         
    }
}
