using DataHUBWebApplication.Data;
using DataHUBWebApplication.DTO;
using DataHUBWebApplication.Interface;
using DataHUBWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DataHUBWebApplication.Services;

public class UserService : IUserService
{
    private readonly DataHubContext _context;

        public UserService(DataHubContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserDisplayDto>> GetUsersAsync()
        {
            return await _context.Users
                .Select(u => new UserDisplayDto
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    UserType = u.UserType,
                    CreatedAt = u.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<UserDisplayDto> GetUserDetailsAsync(Guid id)
        {
            return await _context.Users
                .Where(u => u.UserId == id)
                .Select(u => new UserDisplayDto
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    UserType = u.UserType,
                    CreatedAt = u.CreatedAt
                })
                .FirstOrDefaultAsync();
        }

        public async Task RegisterUserAsync(UserRegistrationDto userDto)
        {
            var user = new User
            {
                UserId = Guid.NewGuid(),
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Email = userDto.Email,
                Password = userDto.Password,
                PhoneNumber = userDto.PhoneNumber,
                GenderType = userDto.GenderType,
                UserType = userDto.UserType,
                CreatedAt = DateTime.UtcNow
            };
            _context.Add(user);
            await _context.SaveChangesAsync();
        }


        public async Task<bool> SignInAsync(UserSignInDto signInDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == signInDto.Email && u.Password == signInDto.Password);
            return user != null;
        }

        public async Task UpdateUserAsync(Guid id, UserUpdateDto userDto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                user.FirstName = userDto.FirstName;
                user.LastName = userDto.LastName;
                user.Email = userDto.Email;
                user.Password = userDto.Password;
                user.PhoneNumber = userDto.PhoneNumber;
                user.GenderType = userDto.GenderType;
                user.UserType = userDto.UserType;
                user.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(Guid id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
}
