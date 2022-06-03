using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class ItemCategory
{
    public int CategoryId {get; set;}
    public string? CategoryName {get; set;}
}