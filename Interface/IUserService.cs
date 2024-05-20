using DataHUBWebApplication.DTO;
namespace DataHUBWebApplication.Interface;

public interface IUserService
{
    Task<IEnumerable<UserDisplayDto>> GetUsersAsync();
    Task<UserDisplayDto> GetUserDetailsAsync(Guid id);
    Task RegisterUserAsync(UserRegistrationDto userDto);
    Task<bool> SignInAsync(UserSignInDto signInDto);
    Task UpdateUserAsync(Guid id, UserUpdateDto userDto);
    Task DeleteUserAsync(Guid id);
}
