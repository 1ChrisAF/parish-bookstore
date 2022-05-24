using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class Book 
{
    public int BookId { get; set; }
    public BookCategory BookCategory {get; set;}
    [Required]
    public string BookTitle {get; set;}
    [Required]
    public string BookAuthor {get; set;}
    [Required]
    public string BookPublisher {get; set;}
    [Required]
    public int BookPublishYear {get; set;}
    [Required]
    public int BookISBN {get; set;}
    public string? BookDescription {get; set;}
}