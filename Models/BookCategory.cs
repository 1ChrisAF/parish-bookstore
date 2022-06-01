using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

public class BookCategory 
{
    public int BookCategoryId {get; set;}

    [Required(ErrorMessage ="Category name is required!")]
    [Display(Name = "Category Name")]
    public string CategoryName {get; set;}

}