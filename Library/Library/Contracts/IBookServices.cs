using Library.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Contracts
{
    public interface IBookServices
    {
        Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync();

        Task AddBookToCollectionAsync(string userId, BookViewModel book);

        Task<BookViewModel?> GetBookByIdAsync(int bookId);
    }
}
