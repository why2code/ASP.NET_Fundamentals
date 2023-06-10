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

//Task AddBookAsync(AddBookViewModel model);
//Task AddBookToCollectionAsync(string userId, BookViewModel book);
//Task EditBookAsync(AddBookViewModel model, int id);
//Task<IEnumerable<AllBookViewModel>> GetAllBooksAsync();
//Task<BookViewModel?> GetBookByIdAsync(int id);
//Task<AddBookViewModel?> GetBookByIdForEditAsync(int id);
//Task<IEnumerable<AllBookViewModel>> GetMyBooksAsync(string userId);
//Task<AddBookViewModel> GetNewAddBookModelAsync();
//Task RemoveBookFromCollectionAsync(string userId, BookViewModel book);