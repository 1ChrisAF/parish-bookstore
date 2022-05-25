using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

public class HomeAltarItem 
{
    public int HomeAltarItemId {get; set;}
    public HomeAltarItemCategory Category {get; set;}
    [Required(ErrorMessage ="Item name is required!")]
    public string Name {get; set;}
    [Required(ErrorMessage ="Item price is required!")]
    public decimal Price {get; set;}
    public string? Description {get; set;}
}