using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Services.ViewModels.Task;


namespace TaskBoardApp.Services.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext dbContext;

        public TaskService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        public async Task<IEnumerable<TaskBoardViewModel>> GetAllTasksForBoardView()
        {
            var boards = await dbContext
                .Boards
                .Select(b => new TaskBoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name
                }).ToListAsync();

            return boards;
            
        }

        public async Task AddTaskToDb(TaskFormModel model, string userId)
        {
            TaskBoardApp.Data.Data.Models.Task task = new TaskBoardApp.Data.Data.Models.Task()
            {
                Title = model.Title,
                Description = model.Description,
                CreatedOn = DateTime.UtcNow,
                BoardId = model.BoardId,
                OwnerId = userId
            };

            await dbContext.Tasks.AddAsync(task);
            await dbContext.SaveChangesAsync();
        }

       
    }
}
