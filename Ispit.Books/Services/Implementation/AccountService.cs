using Ispit.Books.Models.Binding;
using Ispit.Books.Models.Dbo;
using Ispit.Books.Services.Interface;
using Microsoft.AspNetCore.Identity;

namespace Ispit.Books.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;



        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        /// <summary>
        /// Registration User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<bool> RegistrationUser(RegistrationBinding model)
        {
            var exist = await _userManager.FindByEmailAsync(model.Email);

            if (exist != null)
            {
                return false;
            }

            var applicationUser = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email

            };
            applicationUser.EmailConfirmed = true;

            var response = await _userManager.CreateAsync(applicationUser, model.Paswword);

            if (response.Succeeded)
            {
                await _userManager.UpdateAsync(applicationUser);
                await _signInManager.SignInAsync(applicationUser, isPersistent: false);
                return true;
            }
            return false;
        }
    }
}
