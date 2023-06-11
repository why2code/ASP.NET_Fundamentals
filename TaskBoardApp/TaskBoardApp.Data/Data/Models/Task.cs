using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Common.EntityValidationConstants.Task;

namespace TaskBoardApp.Data.Data.Models
{
    public class Task
    {
        public Task()
        {
            this.Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required] [MinLength(TitleMinLength)] 
        public string Title { get; set; } = null!;// a string with min length 5 and max length 70 (required)

        [Required]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!; // a string with min length 10 and max length 1000 (required)
        
        public DateTime? CreatedOn { get; set; } // date and time


        [ForeignKey(nameof(Board))]
        public int BoardId { get; set; } // an integer
        public Board? Board { get; set; } // a Board object



        [ForeignKey(nameof(Owner))] 
        [Required]
        public string OwnerId { get; set; } = null!; // an integer (required)
        public IdentityUser Owner { get; set; } = null!; // an IdentityUser object

    }
}

