using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace parish_bookstore.Models;

public class StoreUser : IdentityUser
{
    public int UserId {get; set;}
}