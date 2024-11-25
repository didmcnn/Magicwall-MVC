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

        #region aboutUs

        public async Task<ActionResult> AboutUsAsync()
        {
            List<About> aboutList = await _aboutService.GetAllAsync();
            return View(aboutList);
        }
        [HttpPost]
        public async Task<ActionResult> AboutUsAsync(About about, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(about.Title) && !string.IsNullOrEmpty(about.Text) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "AboutUs"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    about.Image = location;
                    await _aboutService.CreateAsync(about);
                }
            }
            return RedirectToAction("AboutUs");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteAboutUs(int Id)
        {
            await _aboutService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region Models
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
            return RedirectToAction("Models");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteModel(int Id)
        {
            await _modelsService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region PhotoGallery
        public async Task<ActionResult> PhotoPageItemAsync()
        {
            List<PhotoPageItem> photoPageItems = await _photoPageItemService.GetAllAsync();
            return View(photoPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> PhotoPageItemAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "PhotoPage"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    PhotoPageItem photoPageItem = new()
                    {
                        Name=Name,
                        Image= location
                    };
                    await _photoPageItemService.CreateAsync(photoPageItem);
                }
            }
            return RedirectToAction("PhotoPageItem");
        }
        [HttpDelete]
        public async Task<ActionResult> DeletePhotoItem(int Id)
        {
            await _photoPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region VideoGallery
        public async Task<ActionResult> VideoPageItemAsync()
        {
            List<VideoPageItem> videoPageItems = await _videoPageItemService.GetAllAsync();
            return View(videoPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> VideoPageItemAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "VideoPage"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    VideoPageItem videoPageItem = new()
                    {
                        Name = Name,
                        Video = location
                    };
                    await _videoPageItemService.CreateAsync(videoPageItem);
                }
            }

            return RedirectToAction("VideoPageItem");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteVideoItem(int Id)
        {
            await _videoPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion

        #region Documents
        public async Task<ActionResult> DocumentsPageItemAsync()
        {
            List<DocumentsPageItem> documentsPageItems = await _documentsPageItemService.GetAllAsync();
            return View(documentsPageItems);
        }
        [HttpPost]
        public async Task<ActionResult> DocumentsPageItemAsync(string Name, IFormFile ModelFileInput)
        {
            if (!string.IsNullOrEmpty(Name) && ModelFileInput != null)
            {
                string? location = await FileHelper.UploadAsync(Path.Combine("Files", "DocumentPage"), ModelFileInput, FileType.image);

                if (location != null)
                {
                    DocumentsPageItem documentsPageItem = new()
                    {
                        Name = Name,
                        Image = location
                    };
                    await _documentsPageItemService.CreateAsync(documentsPageItem);
                }
            }
            return RedirectToAction("DocumentsPageItem");
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteDocumentItem(int Id)
        {
            await _documentsPageItemService.DeleteAsync(Id);
            return Ok();
        }
        #endregion


        public ActionResult Referances()
        {
            return View();
        }

        public ActionResult Catalog()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
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

        
        
        public async Task<ActionResult> HomePageItemsAsync()
        {
            List<HomePageItem> homePageItems = await _homePageItemService.GetAllAsync();
            return View(homePageItems);
        }

        [HttpPost]
        public async Task<ActionResult> HomePageItemsAsync(HomePageItem homePageItem)
        {
            await _homePageItemService.CreateAsync(homePageItem);
            return RedirectToAction("HomePageItems");
        }
    }

}
