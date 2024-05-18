﻿using DataHUBWebApplication.Models;
namespace DataHUBWebApplication.Interface;

public interface IUserService
{
    Task<User> GetUserByIdAsync(string userId);
    Task<IEnumerable<User>> GetAllUsersAsync();
    Task AddUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(string userId);
}
