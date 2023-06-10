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
    }
}
