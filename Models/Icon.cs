using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class Icon 
{
    public int IconId {get; set;}
    public IconCategory Category {get; set;}
    [Required(ErrorMessage ="Icon name is required!")]
    public string Name {get; set;}
    [Required(ErrorMessage ="Icon price is required!")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price {get; set;}
    public string? Description {get; set;}

}