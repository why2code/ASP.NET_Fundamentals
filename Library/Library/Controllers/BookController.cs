using System.Security.Claims;
using Library.Contracts;
using Library.Models;
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

        public string IdentifyUser()
        {
            string userId = string.Empty;
            if (User != null)
            {
                userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return userId;
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
                return RedirectToAction("All", "Book");
            }

            string userId = IdentifyUser();
            await bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction(nameof(All));
        }

        public async Task<IActionResult> Mine()
        {
            var myBooks = await bookService.GetMyBooksAsync(IdentifyUser());
            return View(myBooks);
        }


        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All", "Book");
            }

            string userId = IdentifyUser();

            await bookService.RemoveBookFromCollectionAsync(userId, book);

            return RedirectToAction("Mine", "Book");
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var bookToAdd = await bookService.GetNewBookModelToAddAsync();

            if (bookToAdd == null)
            {
                return RedirectToAction("All", "Book");
            }

            return View(bookToAdd);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            await bookService.AddBookAsync(book);
            return RedirectToAction("All", "Book");
        }
    }
}
