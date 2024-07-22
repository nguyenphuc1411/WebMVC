using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyWebsite.Data;
using MyWebsite.Models;

namespace MyWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SanPhamsController : Controller
    {
        private readonly AppDbContext _context;

        public SanPhamsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/SanPhams
        [HttpGet]
        public async Task<IActionResult> Index(string search)
        {
            var listSP = _context.SanPhams.Include(s => s.DanhMuc);
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Search = search;
                return View(await listSP.Where(x=>x.TenSanPham!.Contains(search)).ToListAsync());
            }
            return View(await listSP.ToListAsync());
        }

        // GET: Admin/SanPhams/Create
        public IActionResult Create()
        {
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs.Where(x=>x.TrangThai==true), "DanhMucId", "TenDanhMuc");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sanPham);
                await _context.SaveChangesAsync();
                TempData["CreateMessage"] = "Created Product Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                ViewData["DanhMucId"] = new SelectList(_context.DanhMucs.Where(x => x.TrangThai == true), "DanhMucId", "TenDanhMuc");
            }
            return View(sanPham);
              
        }

        // GET: Admin/SanPhams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs.Where(x => x.TrangThai == true), "DanhMucId", "TenDanhMuc", sanPham.DanhMucId);
            return View(sanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SanPhamId,TenSanPham,Gia,GiamGia,ManHinh,CameraSau,CameraSelfie,CPU,GPU,PIN,RAM,ROM,HDH,XuatXu,MoTa,Kho,HinhAnh,DanhMucId")] SanPham sanPham)
        {
            if (id != sanPham.SanPhamId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sanPham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SanPhamExists(sanPham.SanPhamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["EditMessage"] = "Updated Product Successfully";
                return RedirectToAction(nameof(Index));
            }
            ViewData["DanhMucId"] = new SelectList(_context.DanhMucs.Where(x => x.TrangThai == true), "DanhMucId", "TenDanhMuc", sanPham.DanhMucId);
            return View(sanPham);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var sanPham = await _context.SanPhams.FindAsync(id);
            if (sanPham != null)
            {
                _context.SanPhams.Remove(sanPham);
            }

            await _context.SaveChangesAsync();
            TempData["DeleteMessage"] = "Deleted Product Successfully";
            return RedirectToAction("Index");
        }

        private bool SanPhamExists(int id)
        {
            return _context.SanPhams.Any(e => e.SanPhamId == id);
        }
    }
}
