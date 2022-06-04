using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace parish_bookstore.Models;

public class StoreUser : IdentityUser
{
    [Required]
    [MaxLength(100)]
    public string FirstName {get; set;} = string.Empty;

    [Required]
    [MaxLength(100)]
    public string LastName {get; set;} = string.Empty;
}