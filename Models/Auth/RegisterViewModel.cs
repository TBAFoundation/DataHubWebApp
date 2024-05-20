using DataHUBWebApplication.Enum;
using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.Models.Auth;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    [Required]
    [Display(Name = "First Name")]
    public string FirstName { get; set; } = default!;

    [Required]
    [Display(Name = "Last Name")]
    public string LastName { get; set; } = default!;

    [DataType(DataType.Password)]
    [Display(Name = "Confirm Password")]
    [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
    public string ConfirmPassword { get; set; } = default!;

    [Required]
    [Display(Name = "User Type")]
    public UserType UserType { get; set; } = default!;
}
