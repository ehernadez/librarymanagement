namespace LibraryManagement.Main.DTOs
{
    public class BookReadDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Year { get; set; }
        public string ISBN { get; set; } = null!;
    }
}
