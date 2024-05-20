using DataHUBWebApplication.Enum;
using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.Models;

public class Materials
{
    [Key]
    public int MaterialID { get; set; }

    [Display(Name = "Course ID")]
    [Required(ErrorMessage = "Course ID is required.")]
    public int CourseID { get; set; }

    [Display(Name = "Title")]
    [Required(ErrorMessage = "Title is required.")]
    [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
    public string Title { get; set; } = default!;

    [Display(Name = "Type")]
    [Required(ErrorMessage = "Type is required.")]
    public MaterialType Type { get; set; }

    [Display(Name = "Content")]
    [Required(ErrorMessage = "Content is required.")]
    public string Content { get; set; } = default!;

    [Display(Name = "Created At")]
    public DateTime CreatedAt { get; set; }

    // Navigation property
    public Course Course { get; set; } = default!;
}
