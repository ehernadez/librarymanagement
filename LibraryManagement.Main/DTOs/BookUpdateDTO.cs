using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Main.DTOs
{
    public class BookUpdateDTO
    {
        [Required]
        public string Title { get; set; } = null!;

        [Required]
        public string Author { get; set; } = null!;

        [Range(1, 3000)]
        public int Year { get; set; }

        [Required]
        public string ISBN { get; set; } = null!;
    }
}
