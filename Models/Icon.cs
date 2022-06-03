using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class Icon
{
    public int ItemId {get; set;}

    public int StoreItemId {get; set;}

    [Required(ErrorMessage = "Please select a category.")]
    [Display(Name = "Icon Category")]
    public int CategoryId {get; set;}

    public int BookieId {get; set;}

    [Required(ErrorMessage ="Name is required!")]
    public string? Name {get; set;}

    [Required(ErrorMessage ="Price is required!")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price {get; set;}

    [Required(ErrorMessage ="Quantity is required!")]
    public int Quantity {get; set;}

    public string? Description {get; set;}

    public string? ImageName {get; set;}

    [NotMapped]
    [Display(Name = "Image")]
    public IFormFile? Image {get; set;}
}