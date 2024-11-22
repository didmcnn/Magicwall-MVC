using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Magicwall.Models;
using Microsoft.AspNetCore.Authorization;

namespace Magicwall.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{

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
