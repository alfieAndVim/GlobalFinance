using GlobalFinance.Shared.Models;

namespace GlobalFinance.Client.ServicesInterfaces
{
    public interface IAuthService
    {
        Task<int> LoginUser(UserDto userDto);
        Task LogOutUser();
        Task<int> RegisterUser(UserDto userDto);
    }
}