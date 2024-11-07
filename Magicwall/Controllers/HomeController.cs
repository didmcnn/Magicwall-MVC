using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Magicwall.Models;

namespace Magicwall.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Aboutus()
    {
        return View();
    }
    public IActionResult Accounts()
    {
        return View();
    }
    public IActionResult Contact()
    {
        return View();
    }
    public IActionResult Corporate()
    {
        return View();
    }
    public IActionResult Documents()
    {
        return View();
    }
    public IActionResult Gallery()
    {
        return View();
    }
    public IActionResult Humanresources()
    {
        return View();
    }
    public IActionResult Models()
    {
        return View();
    }
    public IActionResult Photogallery()
    {
        return View();
    }
    public IActionResult Videogallery()
    {
        return View();
    }
    public IActionResult References()
    {
        return View();
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
