using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NguyenHuuTu_BTMVC.Models;

namespace NguyenHuuTu_BTMVC.Controllers
{
    public class LopHocPhansController : Controller
    {
        private readonly AppDbContext _context;

        public LopHocPhansController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LopHocPhans
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.lopHocPhans.Include(l => l.GiaoVien).Include(l => l.KhoaHoc);
            return View(await appDbContext.ToListAsync());
        }

        // GET: LopHocPhans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.lopHocPhans
                .Include(l => l.GiaoVien)
                .Include(l => l.KhoaHoc)
                .FirstOrDefaultAsync(m => m.LopHocPhanId == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Create
        public IActionResult Create()
        {
            ViewData["GiaoVienId"] = new SelectList(_context.giaoViens, "GiaoVienId", "GiaoVienId");
            ViewData["KhoaHocId"] = new SelectList(_context.khoaHocs, "KhoaHocId", "KhoaHocId");
            return View();
        }

        // POST: LopHocPhans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LopHocPhanId,tenLop,GiaoVienId,KhoaHocId")] LopHocPhan lopHocPhan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopHocPhan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiaoVienId"] = new SelectList(_context.giaoViens, "GiaoVienId", "GiaoVienId", lopHocPhan.GiaoVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.khoaHocs, "KhoaHocId", "KhoaHocId", lopHocPhan.KhoaHocId);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.lopHocPhans.FindAsync(id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }
            ViewData["GiaoVienId"] = new SelectList(_context.giaoViens, "GiaoVienId", "GiaoVienId", lopHocPhan.GiaoVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.khoaHocs, "KhoaHocId", "KhoaHocId", lopHocPhan.KhoaHocId);
            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LopHocPhanId,tenLop,GiaoVienId,KhoaHocId")] LopHocPhan lopHocPhan)
        {
            if (id != lopHocPhan.LopHocPhanId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHocPhan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocPhanExists(lopHocPhan.LopHocPhanId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GiaoVienId"] = new SelectList(_context.giaoViens, "GiaoVienId", "GiaoVienId", lopHocPhan.GiaoVienId);
            ViewData["KhoaHocId"] = new SelectList(_context.khoaHocs, "KhoaHocId", "KhoaHocId", lopHocPhan.KhoaHocId);
            return View(lopHocPhan);
        }

        // GET: LopHocPhans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lopHocPhan = await _context.lopHocPhans
                .Include(l => l.GiaoVien)
                .Include(l => l.KhoaHoc)
                .FirstOrDefaultAsync(m => m.LopHocPhanId == id);
            if (lopHocPhan == null)
            {
                return NotFound();
            }

            return View(lopHocPhan);
        }

        // POST: LopHocPhans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lopHocPhan = await _context.lopHocPhans.FindAsync(id);
            if (lopHocPhan != null)
            {
                _context.lopHocPhans.Remove(lopHocPhan);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocPhanExists(int id)
        {
            return _context.lopHocPhans.Any(e => e.LopHocPhanId == id);
        }
    }
}
