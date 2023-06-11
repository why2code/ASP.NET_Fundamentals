using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.ViewModels.Board;

namespace TaskBoardApp.Services.Contracts
{
    public interface IBoardService
    {
        Task<IEnumerable<BoardViewModel>> GetBoardsAndTaskData();
    }
}
