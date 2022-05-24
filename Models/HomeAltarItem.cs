using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class HomeAltarItem 
{
    public int HomeAltarItemId {get; set;}
    public HomeAltarItemCategory Category {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public decimal Price {get; set;}
    public string? Description {get; set;}
}