using Ispit.Books.Models.Binding;
using Ispit.Books.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace Ispit.Books.Services.Interface
{
    public interface IAdminService
    {
        /// <summary>
        /// Get All books from user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<List<BookViewModel>> GetAllBooks(ClaimsPrincipal user);
        /// <summary>
        /// Create new Book
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<BookViewModel> CreateBook(BookBinding model, ClaimsPrincipal user);

        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
         Task<BookViewModel> UpdateBook(BookUpdateBinding model);

        /// <summary>
        /// Book by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<BookViewModel> BookById(int Id);
        List<SelectListItem> AllAuhtors();

        /// <summary>
        /// All publishers
        /// </summary>
        /// <returns></returns>
        List<SelectListItem> AllPublisher();

        /// <summary>
        /// Hard remove book
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<bool> DeleteBook(int Id);
    }
}