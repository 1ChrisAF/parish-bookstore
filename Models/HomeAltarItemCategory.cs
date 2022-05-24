using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class HomeAltarItemCategory
{
    public int HomeAltarItemCategoryId {get; set;}
    [Required]
    public string CategoryName {get; set;}

}