using Ispit.Books.Models.Binding;

namespace Ispit.Books.Services.Interface
{
    public interface IAccountService
    {
        /// <summary>
        /// Registration User
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<bool> RegistrationUser(RegistrationBinding model);
    }
}