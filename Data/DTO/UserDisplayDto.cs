﻿using DataHUBWebApplication.Enum;
using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.DTO;

public class UserDisplayDto
{
    [Key]
    public string UserId { get; set; } = default!;

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

    [Display(Name = "Gender")]
    [Required(ErrorMessage = "Gender type is required.")]
    public GenderType GenderType { get; set; }

    [Display(Name = "User Type")]
    [Required(ErrorMessage = "User type is required.")]
    public UserType UserType { get; set; }
    [Display(Name = "Created Date")]
    public DateTime CreatedAt { get; set; }
}
