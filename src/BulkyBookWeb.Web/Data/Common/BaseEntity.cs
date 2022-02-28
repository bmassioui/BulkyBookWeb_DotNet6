using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Web.Data.Common;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsDeleted { get; set; }

}
