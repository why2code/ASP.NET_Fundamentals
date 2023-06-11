﻿using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoardApp.Services.Contracts;
using TaskBoardApp.Services.ViewModels.Task;
using Task = TaskBoardApp.Data.Data.Models.Task;

namespace TaskBoardApp.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }

        public string IdentifyUser()
        {
            string userId = string.Empty;
            if (User != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return userId;
        }

        public async Task<IActionResult> Create()
        {
            var boardsList = await taskService.GetAllTasksForBoardView();
            TaskFormModel model = new TaskFormModel()
            {
                Boards = boardsList.ToList()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userID = IdentifyUser();
            await taskService.AddTaskToDb(model, userID);

            return RedirectToAction("All", "Board");
        }
    }
}
