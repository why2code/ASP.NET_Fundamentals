using System.Security.Claims;
using Library.Contracts;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookServices bookService;

        public BookController(IBookServices bookService)
        {
            this.bookService = bookService;
        }


        public async Task<IActionResult> All()
        {
            var model = await bookService.GetAllBooksAsync();
            return View(model);
        }


        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction(nameof(All));
            }

            string userId = string.Empty;
            if (User != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            await bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction(nameof(All));
        }

        //To continue

    }
}
