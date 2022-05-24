using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class PrayerRope 
{
    public int PrayerRopeId {get; set;}
    [Required]
    public int KnotCount {get; set;}
    [Required]
    public string Material {get; set;}
    [Required]
    public decimal Price {get; set;}
    public string? Description {get; set;}

}