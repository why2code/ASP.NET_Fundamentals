using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.EntityValidationConstants.Board;


namespace TaskBoardApp.Services.ViewModels.Task
{
    public class TaskBoardViewModel
    {
        public int Id { get; set; } // a unique integer, Primary Key

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!; // a string with min length 3 and max length 30 (required)
    }
}
