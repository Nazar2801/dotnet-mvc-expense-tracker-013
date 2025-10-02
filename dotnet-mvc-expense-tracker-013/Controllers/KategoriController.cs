using Microsoft.AspNetCore.Mvc;
using dotnet_mvc_expense_tracker.Models;

namespace dotnet_mvc_expense_tracker.Controllers
{
    public class KategoriController : Controller
    {
        private static List<Kategori> _data = new List<Kategori>()
        {
            new Kategori { Id = 1, Tipe = "income", Nama = "Gaji", Deskripsi = "Gaji bulanan", Status = "active" },
            new Kategori { Id = 2, Tipe = "expense", Nama = "Makan", Deskripsi = "Pengeluaran harian", Status = "active" }
        };

        public IActionResult Index()
        {
            return View(_data);
        }

        public IActionResult Details(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Kategori model)
        {
            model.Id = _data.Max(x => x.Id) + 1;
            _data.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Kategori model)
        {
            var item = _data.FirstOrDefault(x => x.Id == model.Id);
            if (item == null) return NotFound();

            item.Tipe = model.Tipe;
            item.Nama = model.Nama;
            item.Deskripsi = model.Deskripsi;
            item.Status = model.Status;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _data.FirstOrDefault(x => x.Id == id);
            if (item != null) _data.Remove(item);
            return RedirectToAction("Index");
        }
    }
}
