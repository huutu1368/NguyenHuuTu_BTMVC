using Microsoft.AspNetCore.Mvc;
using NguyenHuuTu_BTMVC.Models;

namespace NguyenHuuTu_BTMVC.Controllers
{
    public class SinhViensController : Controller
    {
        private readonly AppDbContext _db;

        public SinhViensController(AppDbContext db) => _db = db;
        public IActionResult Index() => View(_db.sinhViens.ToList());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(SinhVien sv)
        {
            _db.sinhViens.Add(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id) => View(_db.sinhViens.Find(id));

        [HttpPost]
        public IActionResult Edit(SinhVien sv)
        {
            _db.sinhViens.Update(sv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var sv = _db.sinhViens.Find(id);
            if (sv != null)
            {
                _db.sinhViens.Remove(sv);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}