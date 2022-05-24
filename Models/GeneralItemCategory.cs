using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class GeneralItemCategory
{
    public int GeneralItemCategoryId {get; set;}
    [Required]
    public string CategoryName {get; set;}

}