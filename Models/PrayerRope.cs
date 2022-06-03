using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace parish_bookstore.Models;

public class PrayerRope
{
    [Key]
    public int ItemId {get; set;}

    public int StoreItemId {get; set;}

    [Required(ErrorMessage = "Please select a category.")]
    [Display(Name = "Rope Type")]
    public int CategoryId {get; set;}

    public int BookieId {get; set;}

    [Required(ErrorMessage ="Knot/Bead count is required!")]
    [Display(Name = "Knot/Bead Count")]
    public int KnotCount {get; set;}

    [Required(ErrorMessage = "Material is required!")]
    [Display(Name = "Rope Material")]
    public string? Material {get; set;}

    [Required(ErrorMessage ="Price is required!")]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price {get; set;}

    [Required(ErrorMessage ="Quantity is required!")]
    public int Quantity {get; set;}

    public string? Description {get; set;}

    public string? ImageName {get; set;}

    [NotMapped]
    [Display(Name = "Image")]
    public IFormFile? Image {get; set;}
}