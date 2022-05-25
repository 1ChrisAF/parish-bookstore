using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

public class GeneralItem 
{
    public int GeneralItemId {get; set;}
    public GeneralItemCategory Category {get; set;}
    [Required(ErrorMessage ="Item name is required!")]
    public string Name {get; set;}
    [Required(ErrorMessage ="Item price is required!")]
    public decimal Price {get; set;}
    public string Description {get; set;}

}