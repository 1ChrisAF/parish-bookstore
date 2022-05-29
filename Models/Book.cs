using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class Book 
{
    public int BookId { get; set; }
    [Required(ErrorMessage = "Please select a category.")]
    [Display(Name = "Book Category")]
    public int BookCategoryId { get; set; }  // foreign key property
    
    [Required(ErrorMessage ="Book title is required!")]
    public string Title {get; set;}
    [Required(ErrorMessage ="Book author is required!")]
    public string Author {get; set;}
    [Required(ErrorMessage ="Book publisher is required!")]
    public string Publisher {get; set;}
    [Required(ErrorMessage ="Book publish year is required!")]
    [Display(Name = "Year Pubished")]
    public int PublishYear {get; set;}
    [Required(ErrorMessage ="Book ISBN is required!")]
    public int ISBN {get; set;}
    [Required(ErrorMessage ="Book price is required!")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price {get; set;}
    public string? Description {get; set;}

    public string? ImageName { get; set; }  = "default.png";
  
    [Display(Name = "Image")]  
    [NotMapped]
    public IFormFile? Image { get; set; }


    

    
    
}