using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class TestUser 
{
    [Key]
    public int UserId {get; set;}

    public List<CartItem> Cart {get; set;}
}
