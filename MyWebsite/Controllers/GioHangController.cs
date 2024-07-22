using Microsoft.AspNetCore.Mvc;
using MyWebsite.Data;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace MyWebsite.Controllers
{
    public class GioHangController : Controller
    {
        private readonly AppDbContext _context;
        public GioHangController(AppDbContext context)
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

        public  IActionResult ThemVaoGio(int? SanPhamId)
        {
            List<GioHangVM> carts = SessionHelper.GetObjectFromJson<List<GioHangVM>>(HttpContext.Session, "cart");

            // Chưa có sản phẩm
            if (carts == null)
            {
                List<GioHangVM> listCart = new List<GioHangVM>();
                listCart.Add(new GioHangVM
                {
                    SanPham = _context.SanPhams.Find(SanPhamId),
                    SoLuong = 1
                });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", listCart);
            }
            else
            {
                int index = isExist(SanPhamId);
                if (index != -1)
                {
                    carts[index].SoLuong++;
                }
                else
                {
                    carts.Add(new GioHangVM { SanPham = _context.SanPhams.Find(SanPhamId), SoLuong = 1 });
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carts);

            }
            TempData["CreateMessage"] = "Added to cart successfully";
            return RedirectToAction("Index", "GioHang");
        }

        public IActionResult Remove(int? SanPhamId)
        {
            List<GioHangVM> carts = SessionHelper.GetObjectFromJson<List<GioHangVM>>(HttpContext.Session, "cart");

            int index = isExist(SanPhamId);
            if (index != -1)
            {
                carts.RemoveAt(index);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carts);
            }
            TempData["DeleteMessage"] = "Delete items successfully";
            return RedirectToAction("Index", "GioHang");
        }
        public IActionResult DeleteAll()
        {
            List<GioHangVM> carts = SessionHelper.GetObjectFromJson<List<GioHangVM>>(HttpContext.Session, "cart");
            if (carts != null)
            {
                carts.Clear();
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carts);
                TempData["DeleteMessage"] = "Delete all item successfully";
            }
            return RedirectToAction("Index");
        }

        public IActionResult Giam(int? SanPhamId)
        {
            List<GioHangVM> carts = SessionHelper.GetObjectFromJson<List<GioHangVM>>(HttpContext.Session, "cart");

            int index = isExist(SanPhamId);
            if (index != -1)
            {
                if (carts[index].SoLuong > 1)
                {
                    carts[index].SoLuong--;
                }               
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carts);
            }
            TempData["EditMessage"] = "Updated the number of items successfully";
            return RedirectToAction("Index", "GioHang");
        }
        public IActionResult Tang(int? SanPhamId)
        {
            List<GioHangVM> carts = SessionHelper.GetObjectFromJson<List<GioHangVM>>(HttpContext.Session, "cart");

            int index = isExist(SanPhamId);
            if (index != -1)
            {
                if (carts[index].SoLuong > 0)
                {
                    carts[index].SoLuong++;
                }
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", carts);
            }
            TempData["EditMessage"] = "Updated the number of items successfully";
            return RedirectToAction("Index", "GioHang");
        }

        private int isExist(int? id)
        {
            List<GioHangVM> carts = SessionHelper.GetObjectFromJson<List<GioHangVM>>(HttpContext.Session, "cart");

            for (int i = 0; i < carts.Count(); i++)
            {
                if (carts[i].SanPham!.SanPhamId == id)
                    return i;
            }
            return -1;
        }


        public IActionResult ThanhToan()
        {
            return View(); 
        }
    }
}
