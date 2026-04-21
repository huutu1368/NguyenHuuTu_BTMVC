using Microsoft.AspNetCore.Mvc;
using NguyenHuuTu_BTMVC.Models;

namespace NguyenHuuTu_BTMVC.Controllers
{
    public class GiaoViensController : Controller
    {
        private readonly AppDbContext _db;

        public GiaoViensController(AppDbContext db) => _db = db;
        public IActionResult Index() => View(_db.giaoViens.ToList());
        public IActionResult Create() => View();
        [HttpPost]
        public IActionResult Create(GiaoVien gv)
        {
            _db.giaoViens.Add(gv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id) => View(_db.giaoViens.Find(id));
        [HttpPost]
        public IActionResult Edit(GiaoVien gv)
        {
            _db.giaoViens.Update(gv);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var gv = _db.giaoViens.Find(id);
            if (gv != null)
            {
                _db.giaoViens.Remove(gv);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}