using Library.Contracts;
using Library.Models;
using Library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Data.Models;

namespace Library.Services
{
    public class BookService : IBookServices
    {
        private readonly LibraryDbContext dbContext;

        public BookService(LibraryDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync()
        {
            return await dbContext
                .Books
                .Select(b => new AllBooksViewModel()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Rating = b.Rating,
                    Category = b.Category.Name
                }).ToListAsync();
        }

        public async Task AddBookToCollectionAsync(string userId, BookViewModel book)
        {
            bool alreadyAdded = await dbContext.IdentityUserBook
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);

            if (!alreadyAdded)
            {
                var userBook = new IdentityUserBook
                {
                    CollectorId = userId,
                    BookId = book.Id
                };
                await dbContext.IdentityUserBook.AddAsync(userBook);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<BookViewModel?> GetBookByIdAsync(int bookId)
        {
            return await dbContext.Books
                .Where(b => b.Id == bookId)
                .Select(b => new BookViewModel
                {
                    Id = b.Id,
                    Title = b.Title,
                    Author = b.Author,
                    ImageUrl = b.ImageUrl,
                    Description = b.Description,
                    Rating = b.Rating,
                    CategoryId = b.CategoryId
                }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<MyBooksViewModel>> GetMyBooksAsync(string userId)
        {
            var myBooks = await dbContext
                .IdentityUserBook
                .Where(ub => ub.Collector.Id == userId)
                .Select(ub => new MyBooksViewModel
                {
                    Id = ub.Book.Id,
                    Title = ub.Book.Title,
                    Author = ub.Book.Author,
                    ImageUrl = ub.Book.ImageUrl,
                    Description = ub.Book.Description,
                    Category = ub.Book.Category.Name
                }).ToListAsync();

            return myBooks;
        }

        public async Task RemoveBookFromCollectionAsync(string userId, BookViewModel book)
        {
            var bookToRemove = await dbContext
                .IdentityUserBook
                .FirstOrDefaultAsync(ub => ub.CollectorId == userId && ub.BookId == book.Id);
                

            if (bookToRemove != null)
            {
                dbContext.IdentityUserBook.Remove(bookToRemove);
                await dbContext.SaveChangesAsync();
            }
        }

        public async Task<AddBookViewModel> GetNewBookModelToAddAsync()
        {
            var bookCategories = await dbContext
                .Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();

            var model = new AddBookViewModel
            {
                Categories = bookCategories
            };

            return model;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            Book book = new Book
            {
                Title = model.Title,
                Author = model.Author,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                CategoryId = model.CategoryId,
                Rating = model.Rating
            };

            await dbContext.Books.AddAsync(book);
            await dbContext.SaveChangesAsync();

        }
    }
}
