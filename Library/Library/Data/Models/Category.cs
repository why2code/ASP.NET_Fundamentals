using System.ComponentModel.DataAnnotations;
using static Library.Common.OnModelConfigurationSettings.Category;


namespace Library.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        public IEnumerable<Book> Books { get; set; }
    }
}

