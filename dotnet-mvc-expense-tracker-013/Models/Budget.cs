namespace dotnet_mvc_expense_tracker.Models
{
    public class Budget
    {
        public int Id { get; set; }

        // Relasi ke Kategori
        public int KategoriId { get; set; }
        public string Kategori { get; set; } = string.Empty;

        public string Nama { get; set; } = string.Empty;
        public string Deskripsi { get; set; } = string.Empty;
        public decimal TotalBudget { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRepeat { get; set; }
        public string Status { get; set; } = "active";
    }
}
