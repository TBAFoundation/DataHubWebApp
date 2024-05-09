using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = default!;

        [Display(Name = "Course Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; } = default!;

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; } = default!;

    }
}
