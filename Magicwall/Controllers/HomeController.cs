using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Magicwall.Models;
using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using CoreLayer.Helpers;
using Microsoft.AspNetCore.Mvc.ModelBinding;

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
    private readonly IReferencesPageItemService _referencesPageItemService;
    private readonly IBankAccountService _bankAccountService;
    private readonly IContactService _contactService;
    private readonly IJobApplicationService _jobApplicationService;
    public HomeController(
        IOpenPositionService openPositionService,
        IHomePageItemService homePageItemService,
        IAboutService aboutService,
        IModelsService modelsService,
        IPhotoPageItemService photoPageItemService,
        IVideoPageItemService videoPageItemService,
        IDocumentsPageItemService documentsPageItemService,
        IReferencesPageItemService referencesPageItemService,
        IBankAccountService bankAccountService,
        IContactService contactService,
        IJobApplicationService jobApplicationService)
    {
        _openPositionService = openPositionService;
        _homePageItemService = homePageItemService;
        _aboutService = aboutService;
        _modelsService = modelsService;
        _photoPageItemService = photoPageItemService;
        _videoPageItemService = videoPageItemService;
        _documentsPageItemService = documentsPageItemService;
        _referencesPageItemService = referencesPageItemService;
        _bankAccountService = bankAccountService;
        _contactService = contactService;
        _jobApplicationService = jobApplicationService;
    }

  #region Index
    public async Task<IActionResult> IndexAsync()
    {
        List<HomePageItem> homePageItems = await _homePageItemService.GetAllAsync();
        return View(homePageItems);
    }
    #endregion

    #region Error404
    public IActionResult Error404()
    {
        return View();
    }
    #endregion

    #region Privacy
    public IActionResult Privacy()
    {
        return View();
    }
    #endregion

    #region AboutUs 
    public async Task<IActionResult> AboutUsAsync()
    {
        List<About> aboutList = await _aboutService.GetAllAsync();
        return View(aboutList);
        }
    #endregion

    #region Accounts
    public async Task<IActionResult> AccountsAsync()
    {
        List<BankAccount> bankAccounts = await _bankAccountService.GetAllAsync();
        return View(bankAccounts);
    }
    #endregion

    #region Contact
    public IActionResult Contact()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> ContactAsync(Contact contact)
    {
        if (ModelState.IsValid)
        {
            await _contactService.CreateAsync(contact);
        }
        return RedirectToAction("Contact");
    }
    #endregion

    #region Corporate   
    public IActionResult Corporate()
    {
        return View();
    }
    public async Task<IActionResult> DocumentsAsync()
    {
        List<DocumentsPageItem> documentsPageItems = await _documentsPageItemService.GetAllAsync();
        return View(documentsPageItems);
    }
    #endregion

    #region Gallery 
    public IActionResult Gallery()
    {
        return View();
    }
    #endregion

    #region HumanResources
    public async Task<IActionResult> HumanResourcesAsync()
    {
        var pos = await _openPositionService.GetAllAsync();
        return View(pos);
    }
    [HttpPost]
    public async Task<IActionResult> HumanResourcesAsync(JobApplication jobApplication, IFormFile FormFileInput)
    {
        if (FormFileInput != null)
        {
            ModelState["CVFile"].ValidationState = ModelValidationState.Valid;
        }
        if (ModelState.IsValid)
        {
            string? location = await FileHelper.UploadAsync(Path.Combine("Files", "JobApplications"), FormFileInput, FileType.document);
            if (location != null)
            {
                jobApplication.CVFile = location;
                await _jobApplicationService.CreateAsync(jobApplication);
            }
        }
        return RedirectToAction("HumanResources");
    }
    #endregion

    #region Models
    public async Task<IActionResult> ModelsAsync()
    {
        List<ModelPageItem> modelPageItems = await _modelsService.GetAllAsync();
        return View(modelPageItems);
    }
    #endregion

    #region ModelsDetail
    public IActionResult ModelsDetail()
    {
        return View();
    }
    #endregion
    #region PhotoGallery
    public async Task<IActionResult> PhotoGalleryAsync()
    {
        List<PhotoPageItem> photoPageItems = await _photoPageItemService.GetAllAsync();
        return View(photoPageItems);
    }
    #endregion

    #region VideoGallery
    public async Task<IActionResult> VideoGalleryAsync()
    {
        List<VideoPageItem> videoPageItems = await _videoPageItemService.GetAllAsync();
        return View(videoPageItems);
    }
    #endregion

    #region References
    public async Task<IActionResult> ReferencesAsync()
    {
        List<ReferencesPageItem> references = await _referencesPageItemService.GetAllAsync();
        return View(references);
    }
    #endregion

    #region Error
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    #endregion
}
