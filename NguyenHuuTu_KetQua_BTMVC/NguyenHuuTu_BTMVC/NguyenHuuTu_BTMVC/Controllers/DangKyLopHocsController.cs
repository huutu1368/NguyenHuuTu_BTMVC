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
    public class DangKyLopHocsController : Controller
    {
        private readonly AppDbContext _context;

        public DangKyLopHocsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: DangKyLopHocs
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.dangKyLopHocs.Include(d => d.LopHocPhan).Include(d => d.SinhVien);
            return View(await appDbContext.ToListAsync());
        }

        // GET: DangKyLopHocs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKyLopHoc = await _context.dangKyLopHocs
                .Include(d => d.LopHocPhan)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.DangKyLopHocId == id);
            if (dangKyLopHoc == null)
            {
                return NotFound();
            }

            return View(dangKyLopHoc);
        }

        // GET: DangKyLopHocs/Create
        public IActionResult Create()
        {
            ViewData["LopHocPhanId"] = new SelectList(_context.lopHocPhans, "LopHocPhanId", "LopHocPhanId");
            ViewData["SinhVienId"] = new SelectList(_context.sinhViens, "SinhVienId", "SinhVienId");
            return View();
        }

        // POST: DangKyLopHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DangKyLopHocId,ngaydk,SinhVienId,LopHocPhanId")] DangKyLopHoc dangKyLopHoc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dangKyLopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LopHocPhanId"] = new SelectList(_context.lopHocPhans, "LopHocPhanId", "LopHocPhanId", dangKyLopHoc.LopHocPhanId);
            ViewData["SinhVienId"] = new SelectList(_context.sinhViens, "SinhVienId", "SinhVienId", dangKyLopHoc.SinhVienId);
            return View(dangKyLopHoc);
        }

        // GET: DangKyLopHocs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKyLopHoc = await _context.dangKyLopHocs.FindAsync(id);
            if (dangKyLopHoc == null)
            {
                return NotFound();
            }
            ViewData["LopHocPhanId"] = new SelectList(_context.lopHocPhans, "LopHocPhanId", "LopHocPhanId", dangKyLopHoc.LopHocPhanId);
            ViewData["SinhVienId"] = new SelectList(_context.sinhViens, "SinhVienId", "SinhVienId", dangKyLopHoc.SinhVienId);
            return View(dangKyLopHoc);
        }

        // POST: DangKyLopHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DangKyLopHocId,ngaydk,SinhVienId,LopHocPhanId")] DangKyLopHoc dangKyLopHoc)
        {
            if (id != dangKyLopHoc.DangKyLopHocId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dangKyLopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DangKyLopHocExists(dangKyLopHoc.DangKyLopHocId))
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
            ViewData["LopHocPhanId"] = new SelectList(_context.lopHocPhans, "LopHocPhanId", "LopHocPhanId", dangKyLopHoc.LopHocPhanId);
            ViewData["SinhVienId"] = new SelectList(_context.sinhViens, "SinhVienId", "SinhVienId", dangKyLopHoc.SinhVienId);
            return View(dangKyLopHoc);
        }

        // GET: DangKyLopHocs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dangKyLopHoc = await _context.dangKyLopHocs
                .Include(d => d.LopHocPhan)
                .Include(d => d.SinhVien)
                .FirstOrDefaultAsync(m => m.DangKyLopHocId == id);
            if (dangKyLopHoc == null)
            {
                return NotFound();
            }

            return View(dangKyLopHoc);
        }

        // POST: DangKyLopHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dangKyLopHoc = await _context.dangKyLopHocs.FindAsync(id);
            if (dangKyLopHoc != null)
            {
                _context.dangKyLopHocs.Remove(dangKyLopHoc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DangKyLopHocExists(int id)
        {
            return _context.dangKyLopHocs.Any(e => e.DangKyLopHocId == id);
        }
    }
}
