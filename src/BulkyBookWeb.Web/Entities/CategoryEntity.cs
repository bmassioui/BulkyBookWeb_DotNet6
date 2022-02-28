using BulkyBookWeb.Web.Data.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BulkyBookWeb.Web.Entities;

[Table("Category")]
public class CategoryEntity : BaseEntity
{
    [Required]
    public string Name { get; set; } = null!;

    public int DisplayOrder { get; set; }
}
