using DataHUBWebApplication.Enum;
using DataHUBWebApplication.Models;
using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.DTO;

public class UserUpdateDto : BaseEntity
{
    [Display(Name = "First Name")]
    [Required(ErrorMessage = "First name is required.")]
    [StringLength(100, ErrorMessage = "First name cannot exceed 100 characters.")]
    public string FirstName { get; set; } = default!;

    [Display(Name = "Last Name")]
    [Required(ErrorMessage = "Last name is required.")]
    [StringLength(100, ErrorMessage = "Last name cannot exceed 100 characters.")]
    public string LastName { get; set; } = default!;

    [Display(Name = "Email Address")]
    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email address.")]
    [StringLength(255, ErrorMessage = "Email cannot exceed 255 characters.")]
    public string Email { get; set; } = default!;

    [Display(Name = "Phonenumber")]
    [Required(ErrorMessage = "Phonenumber is required.")]
    [StringLength(13, ErrorMessage = "Phonenumber cannot exceed 13 characters.")]
    public string PhoneNumber { get; set; } = default!;
    [Display(Name = "Password")]
    [Required(ErrorMessage = "Password is required.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = default!;

    [Display(Name = "Gender")]
    [Required(ErrorMessage = "Gender type is required.")]
    public GenderType GenderType { get; set; }

    [Display(Name = "User Type")]
    [Required(ErrorMessage = "User type is required.")]
    public UserType UserType { get; set; }

    [Display(Name = "Address")]
    [Required(ErrorMessage = "Address is required.")]
    [StringLength(255, ErrorMessage = "Address cannot exceed 255 characters.")]
    public string Address { get; set; } = default!;

    [Display(Name = "Level of Education")]
    [Required(ErrorMessage = "Level of education is required.")]
    [StringLength(50, ErrorMessage = "Level of education cannot exceed 50 characters.")]
    public string LevelOfEducation { get; set; } = default!;

    [Display(Name = "Date of Birth")]
    [Required(ErrorMessage = "Date of birth is required.")]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }
}
