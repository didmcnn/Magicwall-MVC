using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Magicwall.Controllers
{
    //[Authorize]
    public class AdminController : Controller
    {
        private readonly IOpenPositionService _openPositionService;
        private readonly IHomePageItemService _homePageItemService;
        private readonly IAboutService _aboutService;
        private readonly IModelsService _modelsService;
        private readonly IPhotoPageItemService _photoPageItemService;
        private readonly IVideoPageItemService _videoPageItemService;
        private readonly IDocumentsPageItemService _documentsPageItemService;
        public AdminController(IOpenPositionService openPositionService,
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

        public ActionResult Index()
        {
            return View();
        }
        public async Task<ActionResult> AboutsAsync()
        {
            List<About> aboutList = await _aboutService.GetAllAsync();
            return View(aboutList);
        }
        [HttpPost]
        public async Task<ActionResult> AboutsAsync(About about)
        {
            await _aboutService.CreateAsync(about);

            List<About> aboutList = await _aboutService.GetAllAsync();
            return View(aboutList);
        }
        public ActionResult Catalog()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public async Task<ActionResult> DocumentsPageItemAsync()
        {
            List<DocumentsPageItem> documentsPageItems = await _documentsPageItemService.GetAllAsync();
            return View(documentsPageItems);
        }
        public ActionResult JobApplication()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> OpenPositionsAsync()
        {
            List<OpenPosition> openPositions = await _openPositionService.GetAllAsync();

            return View(openPositions);
        }

        [HttpPost]
        public async Task<ActionResult> OpenPositionsAsync(OpenPosition position)
        {
            await _openPositionService.CreateAsync(position);

            List<OpenPosition> openPositions = await _openPositionService.GetAllAsync();
            return View(openPositions);
        }
        public async Task<ActionResult> ModelsAsync()
        {
            List<ModelPageItem> modelPageItems = await _modelsService.GetAllAsync();
            return View(modelPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> ModelsAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "Models"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    ModelPageItem modelPageItem = new()
                    {
                        Name = Name,
                        Image = location
                    };
                    await _modelsService.CreateAsync(modelPageItem);
                }
            }

            List<ModelPageItem> modelPageItems = await _modelsService.GetAllAsync();
            return View(modelPageItems);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteModel(int Id)
        {
            await _modelsService.DeleteAsync(Id);
            return Ok();
        }

        public async Task<ActionResult> PhotoPageItemAsync()
        {
            List<PhotoPageItem> photoPageItems = await _photoPageItemService.GetAllAsync();
            return View(photoPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> PhotoPageItemAsync(PhotoPageItem photoPageItem)
        {
            await _photoPageItemService.CreateAsync(photoPageItem);
            List<PhotoPageItem> photoPageItems = await _photoPageItemService.GetAllAsync();
            return View(photoPageItems);
        }
        public ActionResult Referances()
        {
            return View();
        }
        public async Task<ActionResult> VideoPageItemAsync()
        {
            List<VideoPageItem> videoPageItems = await _videoPageItemService.GetAllAsync();
            return View(videoPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> VideoPageItemAsync(VideoPageItem videoPageItem)
        {

            await _videoPageItemService.CreateAsync(videoPageItem);
            List<VideoPageItem> videoPageItems = await _videoPageItemService.GetAllAsync();
            return View(videoPageItems);
        }
        public async Task<ActionResult> HomePageItemsAsync()
        {
            List<HomePageItem> homePageItems = await _homePageItemService.GetAllAsync();
            return View(homePageItems);
        }

        [HttpPost]
        public async Task<ActionResult> HomePageItemsAsync(HomePageItem homePageItem)
        {
            await _homePageItemService.CreateAsync(homePageItem);
            List<HomePageItem> homePageItems = await _homePageItemService.GetAllAsync();
            return View(homePageItems);
        }
    }

}
