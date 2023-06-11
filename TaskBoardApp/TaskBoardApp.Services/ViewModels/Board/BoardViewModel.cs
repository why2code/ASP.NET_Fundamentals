using System.ComponentModel.DataAnnotations;
using TaskBoardApp.Services.ViewModels.Task;
using static TaskBoardApp.Common.EntityValidationConstants.Board;

namespace TaskBoardApp.Services.ViewModels.Board
{
    public class BoardViewModel
    {
        [Key]
        public int Id { get; set; } // a unique integer, Primary Key

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!; // a string with min length 3 and max length 30 (required)

        public IEnumerable<TaskViewModel> Tasks { get; set; } = new List<TaskViewModel>(); // a collection of Task
    }
}
