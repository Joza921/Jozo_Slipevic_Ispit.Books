using AutoMapper;
using Ispit.Books.Models;
using Ispit.Books.Models.Binding;
using Ispit.Books.Models.Dbo;
using Ispit.Books.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace Ispit.Books.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminService _adminService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public AdminController(ILogger<AdminController> logger, IAdminService adminService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _logger = logger;
            _adminService = adminService;
            _userManager = userManager;
            _mapper = mapper;
            
        }
        [Authorize]
        public async Task<IActionResult> GetAllBooks()
        {
          var result = await  _adminService.GetAllBooks(User);
            return View(result);
        }

        [Authorize]
        public async Task<IActionResult> CreateBook()
        {
            ViewBag.Author = _adminService.AllAuhtors();
            ViewBag.Publisher = _adminService.AllPublisher();
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookBinding model)
        {
            var result = await _adminService.CreateBook(model, User);
            return RedirectToAction("GetAllBooks", "Admin");
        }
        public async Task<IActionResult> UpdateBook(int Id)
        {
           var response = await _adminService.BookById(Id);
            return View(_mapper.Map<BookUpdateBinding>(response));
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BookUpdateBinding model)
        {
           var response = await _adminService.UpdateBook(model);
            return RedirectToAction("GetAllBooks", "Admin");
        }

        public async Task<IActionResult> DeleteBook(int Id)
        {
           await _adminService.DeleteBook(Id);
            return RedirectToAction("GetAllBooks", "Admin");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        
    }
}
