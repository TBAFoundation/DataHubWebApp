using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.Models;

public class Enrollment
{
    [Key]
    public int EnrollmentID { get; set; }

    [Display(Name = "User ID")]
    [Required(ErrorMessage = "User ID is required.")]
    public string UserID { get; set; }

    [Display(Name = "Course ID")]
    [Required(ErrorMessage = "Course ID is required.")]
    public int CourseID { get; set; }

    [Display(Name = "Enrollment Date")]
    public DateTime EnrollmentDate { get; set; }
    
    // Navigation properties
    public User User { get; set; }
    public Course Course { get; set; }
}
