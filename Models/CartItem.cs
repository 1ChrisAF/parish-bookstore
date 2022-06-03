using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class CartItem
{
    [Key]
    public IItemType Item {get; set;}
    public int? Quantity {get; set;}

}