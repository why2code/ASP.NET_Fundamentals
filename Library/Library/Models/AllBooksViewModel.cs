using System.ComponentModel.DataAnnotations;
using Library.Data.Models;
using static Library.Common.OnModelConfigurationSettings.Book;

namespace Library.Models
{
    public class AllBooksViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;


        [Required]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

   

        [Required]
        public string Category { get; set; } = null!;

      
    }
}
