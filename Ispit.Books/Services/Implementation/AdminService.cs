using AutoMapper;
using Ispit.Books.Data;
using Ispit.Books.Models.Binding;
using Ispit.Books.Models.Dbo;
using Ispit.Books.Models.ViewModels;
using Ispit.Books.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Ispit.Books.Services.Implementation
{
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly IMapper _mapper;

        public AdminService(ApplicationDbContext db, IMapper mapper, UserManager<ApplicationUser> usermanager)
        {
            _db = db;
            _mapper = mapper;
            _usermanager = usermanager;
        }
        /// <summary>
        /// Get All books from user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public async Task<List<BookViewModel>> GetAllBooks(ClaimsPrincipal user)
        {
            var ApplicationUser = await _usermanager.GetUserAsync(user);
            var dbo = await _db.Books
                .Include(y => y.Author)
                .Include(y => y.Publisher)
                .Where(y => y.UserId == ApplicationUser.Id).ToListAsync();

            return dbo.Select(y => _mapper.Map<BookViewModel>(y)).ToList();
        }
    
        /// <summary>
        /// Create new Book
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<BookViewModel> CreateBook(BookBinding model, ClaimsPrincipal user)
        {
            var ApplicationUser = await _usermanager.GetUserAsync(user);

            model.UserId = ApplicationUser.Id;
            await  _db.Books.AddAsync(_mapper.Map<Book>(model));
            await _db.SaveChangesAsync();
            return _mapper.Map<BookViewModel>(model);
        }

        /// <summary>
        /// Book by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<BookViewModel> BookById(int Id)
        {
            var dbo = await _db.Books.Where(y => y.Id == Id).FirstOrDefaultAsync();
            return _mapper.Map<BookViewModel>(dbo);
        }
        /// <summary>
        /// Update book
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// 


        public async Task<BookViewModel> UpdateBook(BookUpdateBinding model)
        {
            var dbo = await _db.Books
                .Where(Y => Y.Id == model.Id).FirstOrDefaultAsync();
            _mapper.Map(model, dbo);
            await _db.SaveChangesAsync();
            return _mapper.Map<BookViewModel>(dbo);
        }
        /// <summary>
        /// Hard remove book
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteBook (int Id)
        {
            var book = await _db.Books.Where(x => x.Id == Id).FirstOrDefaultAsync();
           _db.Books.Remove(book);
           await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// All Authors 
        /// </summary>
        /// <returns></returns>
        public  List<SelectListItem> AllAuhtors()
        {
            var Authors = new List<SelectListItem>();

            var response = _db.Authors.ToList();
            List<AuthorViewModel> AuthorsView = _mapper.Map<List<AuthorViewModel>>(response);
            Authors = AuthorsView.Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.FirstName.ToString() + " " + p.LastName.ToString()
            }).ToList();

            var defu = new SelectListItem()
            {
                Value = "",
                Text = "Odaberi"
            };
            Authors.Insert(0, defu);


            return Authors;
        }
        /// <summary>
        /// All publishers
        /// </summary>
        /// <returns></returns>
        public List<SelectListItem> AllPublisher()
        {
            var Publishers = new List<SelectListItem>();

            var response = _db.Publishers.ToList();
            List<PublisherViewModel> PublishersView = _mapper.Map<List<PublisherViewModel>>(response);
            Publishers = PublishersView.Select(p => new SelectListItem()
            {
                Value = p.Id.ToString(),
                Text = p.Name.ToString(),
                
            }).ToList();

            var defu = new SelectListItem()
            {
                Value = "",
                Text = "Odaberi"
            };
            Publishers.Insert(0, defu);


            return Publishers;
        }

        
    }
}
