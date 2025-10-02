using System.Collections.Generic;

namespace dotnet_mvc_expense_tracker.Models
{
    public static class FakeDB
    {
        public static List<Kategori> Kategoris { get; set; } = new List<Kategori>();
        public static List<Budget> Budgets { get; set; } = new List<Budget>();
    }
}
