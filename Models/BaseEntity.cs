using System.ComponentModel.DataAnnotations;

namespace DataHUBWebApplication.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public Guid  UserId { get; set; } = default!;

        [Display(Name = "Created Date")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Date Updated")]
        public DateTime? UpdatedAt { get; set; }

    }
}
