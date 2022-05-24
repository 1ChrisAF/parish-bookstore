using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class GeneralItemCategory
{
    public int GeneralItemCategoryId {get; set;}
    [Required(ErrorMessage ="Category name is required!")]
    public string CategoryName {get; set;}

}