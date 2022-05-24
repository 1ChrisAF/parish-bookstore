using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class BookCategory 
{
    public int BookCategoryId {get; set;}
    [Required(ErrorMessage ="Category name is required!")]
    public string CategoryName {get; set;}
}