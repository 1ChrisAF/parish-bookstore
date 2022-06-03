using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class CartItem
{
    [Key]
    public int CartItemId {get; set;}
    public int CartId {get; set;}
    public ItemType Item {get; set;}
    public int Quantity {get; set;}
}