using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TaskBoardApp.Data.Data;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Services.ViewModels.Board;
using TaskBoardApp.Services.ViewModels.Task;

namespace TaskBoardApp.Services.Services
{
    public class BoardService : IBoardService
    {
        private readonly ApplicationDbContext dbContext;

        public BoardService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<BoardViewModel>> GetBoardsAndTaskData()
        {
            var boards = await dbContext
                .Boards
                .Select(b => new BoardViewModel()
                {
                    Id = b.Id,
                    Name = b.Name,
                    Tasks = b.Tasks
                        .Select(t => new TaskViewModel
                        {
                            Id = t.Id.ToString(),
                            Title = t.Title,
                            Description = t.Description,
                            Owner = t.Owner.UserName
                        })
                }).ToListAsync();
            return boards;
        }
    }
}
