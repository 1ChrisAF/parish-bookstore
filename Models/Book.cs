using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class Book 
{
    public int BookId { get; set; }
    public BookCategory Category {get; set;}
    [Required]
    public string Title {get; set;}
    [Required]
    public string Author {get; set;}
    [Required]
    public string Publisher {get; set;}
    [Required]
    public int PublishYear {get; set;}
    [Required]
    public int ISBN {get; set;}
    [Required]
    public decimal Price {get; set;}
    public string? Description {get; set;}
}