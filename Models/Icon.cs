using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class Icon 
{
    public int IconId {get; set;}
    public IconCategory Category {get; set;}
    [Required(ErrorMessage ="Icon name is required!")]
    public string Name {get; set;}
    [Required(ErrorMessage ="Icon price is required!")]
    public decimal Price {get; set;}
    public string? Description {get; set;}

}