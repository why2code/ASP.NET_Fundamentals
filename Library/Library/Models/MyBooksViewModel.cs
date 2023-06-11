using System.ComponentModel.DataAnnotations;
using static Library.Common.OnModelConfigurationSettings.Book;

namespace Library.Models
{
    public class MyBooksViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required] 
        public string Category { get; set; } = null!;

        [Required]
        public string ImageUrl { get; set; } = null!;

   
   }
}
