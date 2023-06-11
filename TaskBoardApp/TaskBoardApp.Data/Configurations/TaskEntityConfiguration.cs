using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task = TaskBoardApp.Data.Data.Models.Task;
namespace TaskBoardApp.Data.Configurations
{
    public class TaskEntityConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasData(this.GenerateTasks());
        }


        public ICollection<Task> GenerateTasks()
        {
            ICollection<Task> tasks = new HashSet<Task>()
            {
                new Task()
                {
                    Title = "Improve CSS styles",
                    Description = "Improve CSS styles of the application",
                    CreatedOn = DateTime.UtcNow.AddDays(-200),
                    OwnerId = "ce27f01b-ac6c-4962-915a-fe92495d85ec",
                    BoardId = 1
                },
                new Task()
                {
                    Title = "What is HTML?",
                    Description = "This is so complicated man",
                    CreatedOn = DateTime.UtcNow.AddDays(-130),
                    OwnerId = "d85e761e-20a2-49fd-bd47-fb31436f4f0a",
                    BoardId = 2
                },
                new Task()
                {
                    Title = "MVC is LITT",
                    Description = "I will learn this thing someday...",
                    CreatedOn = DateTime.UtcNow.AddDays(-5),
                    OwnerId = "ce27f01b-ac6c-4962-915a-fe92495d85ec",
                    BoardId = 3
                },
                new Task()
                {
                    Title = "Time to sleep soon!",
                    Description = "Chickens already sleeping",
                    CreatedOn = DateTime.UtcNow.AddDays(-65),
                    OwnerId = "d85e761e-20a2-49fd-bd47-fb31436f4f0a",
                    BoardId = 4
                }
            };

            return tasks;
        }
      
    }
}
