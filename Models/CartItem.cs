using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class CartItem
{
    [Key]
    public int CartItemId {get; set;}
    public int UserId {get; set;}           // Identifies the user to whom the Cart belongs
    public int StoreItemId {get; set;}      // Identifies the object type
    public int ItemId {get; set;}           // Identifies the specific instance of the object type
    public int Quantity {get; set;}         // Desired quantity of instances of objects of a certain type
}