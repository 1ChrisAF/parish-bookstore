using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class Book 
{
    public int ItemId {get; set;}

    public int StoreItemId {get; set;}

    [Required(ErrorMessage = "Please select a category.")]
    [Display(Name = "Book Category")]
    public int CategoryId {get; set;}

    public int BookieId {get; set;}

    [Required(ErrorMessage ="Title is required!")]
    [Display(Name = "Title")]
    public string? Name {get; set;}

    [Required(ErrorMessage ="Author is required!")]
    public string? Author {get; set;}

    [Required(ErrorMessage = "Page count is required!")]
    [Display(Name = "Page Count")]
    public int PageCount {get; set;}

    [Required(ErrorMessage = "Publisher is required!")]
    public string? Publisher {get; set;}

    [Required(ErrorMessage = "Publish year is required!")]
    [Display(Name = "Year Published")]
    public int PublishYear {get; set;}

    [Required(ErrorMessage = "ISBN is required!")]
    public string? ISBN {get; set;}

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