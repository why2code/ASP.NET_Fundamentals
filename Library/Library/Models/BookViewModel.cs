﻿using System.ComponentModel.DataAnnotations;
using Library.Data.Models;
using static Library.Common.OnModelConfigurationSettings.Book;

namespace Library.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(TitleLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(AuthorMaxLength, MinimumLength = AuthorMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MinLength(5)]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;


        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
    }
}
