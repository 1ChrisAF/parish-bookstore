using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class BookCategory 
{
    public int BookCategoryId {get; set;}
    [Required]
    public string BookCategoryName {get; set;}
}