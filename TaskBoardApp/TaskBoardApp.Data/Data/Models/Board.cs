using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.EntityValidationConstants.Board;

namespace TaskBoardApp.Data.Data.Models
{
    public class Board
    {
        public Board()
        {
            this.Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; } // a unique integer, Primary Key

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!; // a string with min length 3 and max length 30 (required)
       
        public IEnumerable<Task> Tasks { get; set; } // a collection of Task
    }
}

//• Id – a unique integer, Primary Key
//• Name – a string with min length 3 and max length 30 (required)
//    • Tasks – a collection of Task