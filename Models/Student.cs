using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Display(Name = "Student Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = default!;

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = default!;
    }
}
