using Microsoft.AspNetCore.Mvc;
using dotnet_mvc_expense_tracker.Models;

namespace dotnet_mvc_expense_tracker.Controllers
{
    public class BudgetController : Controller
    {
        // Data sementara (in-memory)
        private static List<Budget> _budgets = new List<Budget>()
        {
            new Budget { Id = 1, Kategori = "Gaji", Nama = "Budget Bulanan", Deskripsi = "Untuk kebutuhan rumah", TotalBudget = 5000000, StartDate = DateTime.Now, EndDate = DateTime.Now.AddMonths(1), IsRepeat = true, Status = "active" }
        };

        // Ambil kategori dari controller Kategori (dummy)
        private static List<string> _kategoriList = new List<string>()
        {
            "Gaji", "Makan", "Transportasi"
        };

        public IActionResult Index()
        {
            return View(_budgets);
        }

        public IActionResult Details(int id)
        {
            var item = _budgets.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        public IActionResult Create()
        {
            ViewBag.KategoriList = _kategoriList;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Budget model)
        {
            model.Id = _budgets.Max(x => x.Id) + 1;
            _budgets.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = _budgets.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            ViewBag.KategoriList = _kategoriList;
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(Budget model)
        {
            var item = _budgets.FirstOrDefault(x => x.Id == model.Id);
            if (item == null) return NotFound();

            item.Kategori = model.Kategori;
            item.Nama = model.Nama;
            item.Deskripsi = model.Deskripsi;
            item.TotalBudget = model.TotalBudget;
            item.StartDate = model.StartDate;
            item.EndDate = model.EndDate;
            item.IsRepeat = model.IsRepeat;
            item.Status = model.Status;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = _budgets.FirstOrDefault(x => x.Id == id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _budgets.FirstOrDefault(x => x.Id == id);
            if (item != null) _budgets.Remove(item);
            return RedirectToAction("Index");
        }
    }
}
