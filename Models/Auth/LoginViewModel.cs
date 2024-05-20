using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.Models.Auth;

public class LoginViewModel
{
    [Required(ErrorMessage = "Username is required!")]
    [EmailAddress]
    public string Email { get; set; } = default!;

    [Required(ErrorMessage = "Password is required!")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    [Display(Name = "Remember me?")]
    public bool RememberMe { get; set; }
}
