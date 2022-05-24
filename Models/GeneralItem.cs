using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class GeneralItem 
{
    public int GeneralItemId {get; set;}
    public GeneralItemCategory Category {get; set;}
    [Required]
    public string Name {get; set;}
    [Required]
    public decimal Price {get; set;}
    public string Description {get; set;}

}