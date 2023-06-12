using Microsoft.AspNetCore.Mvc;
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

        public async Task<TaskDetailsViewModel> GetTaskDetails(string id)
        {
            var task = await dbContext.Tasks
                .Include(t => t.Board)
                .Include(t => t.Owner)
                .FirstOrDefaultAsync(t => t.Id.ToString() == id);


            TaskDetailsViewModel taskDetails = new TaskDetailsViewModel()
            {
                Id = task.Id.ToString(),
                Title = task.Title,
                Description = task.Description,
                CreatedOn = DateTime.Parse(task.CreatedOn.ToString()),
                Board = task.Board.Name,
                Owner = task.Owner.UserName
            };
            return taskDetails;
        }

        public async Task<TaskFormModel> GetTaskForEdit(string id)
        {
            var task = await dbContext.Tasks
                .Include(t => t.Board)
                .Include(t => t.Owner)
                .FirstOrDefaultAsync(t => t.Id.ToString() == id);

            return new TaskFormModel()
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = await GetAllTasksForBoardView()
            };
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


        public async Task EditTask(TaskFormModel model, string id)
        {
            var task = await dbContext
                .Tasks
                .FirstOrDefaultAsync(t => t.Id.ToString() == id);

            task.Title = model.Title;
            task.Description = model.Description;
            task.BoardId = model.BoardId;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteTask(TaskViewModel model)
        {
            var task = await dbContext
                .Tasks
                .FirstOrDefaultAsync(t => t.Id.ToString() == model.Id);
            if (task == null)
            {
                return;
            }
            dbContext.Tasks.Remove(task);
            await dbContext.SaveChangesAsync();
        }

    }
}
