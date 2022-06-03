using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class StoreItem
{
    [Key]
    public int StoreItemId {get; set;}
    public string? ItemName {get; set;}
}