using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Magicwall.Models;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;

namespace Magicwall.Controllers;

[AllowAnonymous]
public class HomeController : Controller
{
    private readonly IOpenPositionService _openPositionService;
    private readonly IHomePageItemService _homePageItemService;
    private readonly IAboutService _aboutService;
    private readonly IModelsService _modelsService;
    private readonly IPhotoPageItemService _photoPageItemService;
    private readonly IVideoPageItemService _videoPageItemService;
    private readonly IDocumentsPageItemService _documentsPageItemService;
    public HomeController(IOpenPositionService openPositionService,
        IHomePageItemService homePageItemService, IAboutService aboutService, IModelsService modelsService,
        IPhotoPageItemService photoPageItemService, IVideoPageItemService videoPageItemService, IDocumentsPageItemService documentsPageItemService)
    {
        _openPositionService = openPositionService;
        _homePageItemService = homePageItemService;
        _aboutService = aboutService;
        _modelsService = modelsService;
        _photoPageItemService = photoPageItemService;
        _videoPageItemService = videoPageItemService;
        _documentsPageItemService = documentsPageItemService;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Error404()
    {
        return View();
    }
    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> AboutUsAsync()
    {
        List<About> aboutList = await _aboutService.GetAllAsync();
        return View(aboutList);
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
    public async Task<IActionResult> ModelsAsync()
    {
        List<ModelPageItem> modelPageItems = await _modelsService.GetAllAsync();
        return View(modelPageItems);
    }
    public async Task<IActionResult> PhotoGalleryAsync()
    {
        List<PhotoPageItem> photoPageItems = await _photoPageItemService.GetAllAsync();
        return View(photoPageItems);
    }
    public async Task<IActionResult> VideoGalleryAsync()
    {
        List<VideoPageItem> videoPageItems = await _videoPageItemService.GetAllAsync();
        return View(videoPageItems);
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
