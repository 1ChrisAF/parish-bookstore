using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using parish_bookstore.Models;

namespace parish_bookstore.Controllers;

public class PrayerRopeController : Controller 
{
    public IActionResult Index()
    {
        return View();
    }
}