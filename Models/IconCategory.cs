using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class IconCategory
{
    public int IconCategoryId {get; set;}
    [Required(ErrorMessage ="Category name is required!")]
    public string CategoryName {get; set;}
}