using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class TestUser 
{
    public int UserId {get; set;}
    public Dictionary<IItemType, int> Cart = new Dictionary<IItemType, int>();
}