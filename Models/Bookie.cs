using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class Bookie
{
    [Key]
    public int BookieId {get; set;}
    public string? ImageName {get; set;}
}