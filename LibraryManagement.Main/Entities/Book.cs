namespace LibraryManagement.Main.Entities
{
    public class Book : AuditableEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int Year { get; set; }
        public string ISBN { get; set; } = null!;
    }
}
