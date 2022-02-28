using System.ComponentModel.DataAnnotations;

namespace BulkyBookWeb.Web.Data.Common;

public class BaseEntity
{
    [Key]
    public Guid Id { get; set; }

    [Display(Name = "Created At")]
    [DataType(DataType.Date)]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy HH:mm:ss}")] 
    public DateTime CreatedAt { get; set; }

    [Display(Name = "Updated At")]
    [DataType(DataType.Date)]
    public DateTime UpdatedAt { get; set; }
    
    [Display(Name = "Deleted")]
    public bool IsDeleted { get; set; }

}
