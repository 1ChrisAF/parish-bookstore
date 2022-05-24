using System.ComponentModel.DataAnnotations;

namespace parish_bookstore.Models;

class PrayerRope 
{
    public int PrayerRopeId {get; set;}
    [Required(ErrorMessage ="Knot count is required!")]
    public int KnotCount {get; set;}
    [Required(ErrorMessage ="Rope material is required!")]
    public string Material {get; set;}
    [Required(ErrorMessage ="Rope price is required!")]
    public decimal Price {get; set;}
    public string? Description {get; set;}

}