using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskBoardApp.Services.ViewModels.Task;

namespace TaskBoardApp.Services.Contracts
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskBoardViewModel>> GetAllTasksForBoardView();

        Task AddTaskToDb(TaskFormModel model, string userId);
    }
}
