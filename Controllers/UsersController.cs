﻿using Microsoft.AspNetCore.Mvc;
using DataHUBWebApplication.DTO;
using DataHUBWebApplication.Interface;

namespace DataHUBWebApplication.Controllers;

public class UsersController : Controller
{
    private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Users
        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }

        // GET: Users/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var userDto = await _userService.GetUserDetailsAsync(id);
            if (userDto == null)
            {
                return NotFound();
            }
            return View(userDto);
        }

        // GET: Users/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: Users/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegistrationDto userDto)
        {
            if (ModelState.IsValid)
            {
                if (userDto.Password != userDto.ConfirmPassword)
                {
                    ModelState.AddModelError("ConfirmPassword", "The password and confirmation password do not match.");
                    return View(userDto);
                }

                await _userService.RegisterUserAsync(userDto);
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
        }

        // POST: Users/SignIn
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(UserSignInDto signInDto)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _userService.SignInAsync(signInDto);
                if (signInResult)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return View(signInDto);
        }

        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
            var user = await _userService.GetUserDetailsAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, UserUpdateDto userDto)
        {
            if (id != userDto.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _userService.UpdateUserAsync(id, userDto);
                return RedirectToAction(nameof(Index));
            }
            return View(userDto);
        }

        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserDetailsAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return RedirectToAction(nameof(Index));
        }
}