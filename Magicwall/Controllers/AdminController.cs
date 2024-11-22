using BusinessLayer.Abstaract;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Magicwall.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IOpenPositionService _openPositionService;
        private readonly IHomePageItemService _homePageItemService;
        private readonly IAboutService _aboutService;
        private readonly IModelsService _modelsService;
        private readonly IPhotoPageItemService _photoPageItemService;
        private readonly IVideoPageItemService _videoPageItemService;
        public AdminController(IAuthorizationService authorizationService,IOpenPositionService openPositionService,
            IHomePageItemService homePageItemService, IAboutService aboutService, IModelsService modelsService,
            IPhotoPageItemService photoPageItemService, IVideoPageItemService videoPageItemService)
        {
            _authorizationService = authorizationService;
            _openPositionService = openPositionService;
            _homePageItemService = homePageItemService;
            _aboutService = aboutService;
            _modelsService = modelsService;
            _photoPageItemService = photoPageItemService;
            _videoPageItemService = videoPageItemService;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Abouts()
        {
            List<About> aboutList = _aboutService.GetListAll();
            return View(aboutList);
        }
        [HttpPost]
        public ActionResult Abouts(About about)
        {
            _aboutService.Add(about);

            List<About> aboutList = _aboutService.GetListAll();
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
        public ActionResult Documents()
        {
            return View();
        }
        public ActionResult JobApplication()
        {
            return View();
        }
        [HttpGet]
        public ActionResult OpenPositions()
        {
            List<OpenPosition> openPositions = _openPositionService.GetListAll();

            return View(openPositions);
        }

        [HttpPost]
        public ActionResult OpenPositions(string Name)
        {
            OpenPosition position = new() {
                Name = Name
            };

            _openPositionManager.Add(position);

            List<OpenPosition> openPositions = _openPositionManager.GetListAll();
            return View(openPositions);
        }
        public ActionResult Models()
        {
            List<ModelPageItem> modelPageItems = _modelsManager.GetListAll();
            return View(modelPageItems);
        }
        [HttpPost]
        public ActionResult Models(string Name, string Image)
        {
            ModelPageItem modelPageItem = new()
            {
                Name = Name,    
                Image = Image
            };
            _modelsManager.Add(modelPageItem);
            List<ModelPageItem> modelPageItems = _modelsManager.GetListAll();
            return View(modelPageItems);
        }
        public ActionResult PhotoPageItem()
        {
            List<PhotoPageItem> photoPageItems = _photoPageItemManager.GetListAll();
            return View(photoPageItems);
        }
        [HttpPost]
        public ActionResult PhotoPageItem(string Image, string Name)
        {
            PhotoPageItem photoPageItem = new()
            {
                Image = Image,
                Name = Name
            };
            _photoPageItemManager.Add(photoPageItem);
            List<PhotoPageItem> photoPageItems = _photoPageItemManager.GetListAll();
            return View(photoPageItems);
        }
        public ActionResult Referances()
        {
            return View();
        }
        public ActionResult VideoPageItem()
        {
            List<VideoPageItem> videoPageItems = _videoPageItemManager.GetListAll();
            return View(videoPageItems);
        }
        [HttpPost]
        public ActionResult VideoPageItem(string Name, string Video)
        {
            VideoPageItem videoPageItem = new()
            {
                Name = Name,
                Video = Video
            };
            _videoPageItemManager.Add(videoPageItem);
            List<VideoPageItem> videoPageItems = _videoPageItemManager.GetListAll();
            return View(videoPageItems);
        }
        public ActionResult HomePageItems()
        {
            List<HomePageItem> homePageItems = _homePageItemManager.GetListAll();
            return View(homePageItems);
        }
        
        [HttpPost]
        public ActionResult HomePageItems(string Title, string Text, string Image)  
        {
            HomePageItem homePageItem = new()
            {
                Title = Title,
                Text = Text,
                Image = Image
            };
            _homePageItemManager.Add(homePageItem);
            List<HomePageItem> homePageItems = _homePageItemManager.GetListAll();
            return View(homePageItems);
        }
    }

}
