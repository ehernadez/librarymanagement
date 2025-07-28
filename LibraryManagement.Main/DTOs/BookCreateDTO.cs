using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Main.DTOs
{
    public class BookCreateDTO
    {
        [Required]
        public string Title { get; set; } = null!;
        [Required]
        public string Author { get; set; } = null!;
        [Range(1900, 2025)]
        public int Year { get; set; }
        public string ISBN { get; set; } = null!;
    }
}
