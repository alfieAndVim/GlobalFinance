using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.Services
{
    public interface IAuthService
    {
        Task<string> GetCustomerId(string email);
        Task<int> LoginUser(UserDto userDto);
        Task LogOutUser();
        Task<int> RegisterUser(UserDto userDto);
    }
}