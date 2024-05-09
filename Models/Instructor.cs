using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.Models
{
    public class Instructor
    {
        public int Id { get; set; }

        [Display(Name = "Instructor Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = default!;

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = default!;

        [Display(Name = "Specialization")]
        [Required(ErrorMessage = "Specialization is required.")]
        public string Specialization { get; set; } = default!;
    }
}
