using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class Cart
{
    [Key]
    public int CartId {get; set;}
    
}

