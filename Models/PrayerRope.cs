using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class PrayerRope 
{
    public int PrayerRopeId {get; set;}
    public int Bookie {get; set;}
    [Required(ErrorMessage ="Knot count is required!")]
    public int KnotCount {get; set;}
    [Required(ErrorMessage ="Rope material is required!")]
    public string Material {get; set;}
    [Required(ErrorMessage ="Rope price is required!")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price {get; set;}
    [Required(ErrorMessage = "Quantity is required!")]
    public int Quantity {get; set;}
    public string? Description {get; set;}

    public string ImageName { get; set; }  = "default.png";
  
    [Display(Name = "Image")]  
    [NotMapped]
    public IFormFile? Image { get; set; }

}