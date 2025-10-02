    namespace dotnet_mvc_expense_tracker.Models
    {
        public class Kategori
        {
            public int Id { get; set; }
            public string Tipe { get; set; } = string.Empty;   // income / expense
            public string Nama { get; set; } = string.Empty;
            public string Deskripsi { get; set; } = string.Empty;
            public string Status { get; set; } = "active";     // active / not active
        }
    }
