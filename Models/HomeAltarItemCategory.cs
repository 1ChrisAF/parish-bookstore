using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class HomeAltarItemCategory
{
    public int HomeAltarItemCategoryId {get; set;}
    [Required(ErrorMessage ="Category name is required!")]
    public string CategoryName {get; set;}

}