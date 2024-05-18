using System.ComponentModel.DataAnnotations;
using static Mysqlx.Notice.Warning.Types;

namespace DataHUBWebApplication.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }

        [Display(Name = "Course Title")]
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string CourseName { get; set; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category is required.")]
        [StringLength(100, ErrorMessage = "Category cannot exceed 100 characters.")]
        public string Category { get; set; }

        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 10000, ErrorMessage = "Price must be between 0 and 10,000.")]
        public decimal Price { get; set; }

        [Display(Name = "Duration (hours)")]
        [Required(ErrorMessage = "Duration is required.")]
        [Range(1, 500, ErrorMessage = "Duration must be between 1 and 500 hours.")]
        public int Duration { get; set; }

        [Display(Name = "Level")]
        [Required(ErrorMessage = "Level is required.")]
        public Level Level { get; set; }

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<Materials> Material { get; set; }
    }
}
