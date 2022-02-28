using BulkyBookWeb.Web.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBookWeb.Web.Entities;

[Table("Category")]
public class CategoryEntity : BaseEntity
{
    [Required]
    [StringLength (maximumLength:100, ErrorMessage = "Name must be between 5 to 100 chars.", MinimumLength = 5)]
    public string Name { get; set; } = null!;

    [Display(Name = "Display Order")]
    [Range(1, 100, ErrorMessage = "Display Order must be between 1 to 100.")]
    public int DisplayOrder { get; set; }
}
