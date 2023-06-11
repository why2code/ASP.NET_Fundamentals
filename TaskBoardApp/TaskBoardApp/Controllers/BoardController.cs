using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Models;
using TaskBoardApp.Services.Contracts;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class BoardController : Controller
    {
        private readonly IBoardService boardService;

       
        public BoardController(IBoardService boardService, ILogger<BoardController> logger)
        {
            this.boardService = boardService;

        }

        public async Task<IActionResult> All()
        {
            var boards = await boardService.GetBoardsAndTaskData();
            return View(boards);
        }
    }
}
