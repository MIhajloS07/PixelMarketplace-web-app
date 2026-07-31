using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Game Title")]
        public string? Title { get; set; }

        [Required]
        [Display(Name = "Game Author")]
        public string? Author { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime releaseDate { get; set; }
    }
}
