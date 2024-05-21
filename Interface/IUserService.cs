using DataHUBWebApplication.DTO;
namespace DataHUBWebApplication.Interface;

public interface IUserService
{
    Task<IEnumerable<UserDisplayDto>> GetUsersAsync();
    Task<UserDisplayDto?> GetUserDetailsAsync(string id);
    Task RegisterUserAsync(UserRegistrationDto userDto);
    Task<bool> SignInAsync(UserSignInDto signInDto);
    Task UpdateUserAsync(string id, UserUpdateDto userDto);
    Task DeleteUserAsync(string id);
}
