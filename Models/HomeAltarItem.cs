using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class HomeAltarItem 
{
    public int HomeAltarItemId {get; set;}
    [Required(ErrorMessage = "Please select a category.")]
    [Display(Name = "Category")]
    public int CategoryId {get; set;}
    
    [Required(ErrorMessage ="Item name is required!")]
    public string Name {get; set;}
    [Required(ErrorMessage ="Item price is required!")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price {get; set;}
    public string? Description {get; set;}
}