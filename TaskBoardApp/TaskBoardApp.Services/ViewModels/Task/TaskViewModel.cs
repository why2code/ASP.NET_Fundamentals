using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Common.EntityValidationConstants.Task;


namespace TaskBoardApp.Services.ViewModels.Task
{
    public class TaskViewModel
    {
        [Required]
        public string Id { get; set; } = null;

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)] 
        public string Title { get; set; } = null!;// a string with min length 5 and max length 70 (required)

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        public string Owner { get; set; } = null!;
    }
}
