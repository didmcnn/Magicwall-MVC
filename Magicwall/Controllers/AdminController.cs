using BusinessLayer.Abstaract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Magicwall.Controllers
{
    public class AdminController : Controller
    {
        private readonly Context _context = new();
        private readonly OpenPositionManager _openPositionManager;
        private readonly HomePageItemManager _homePageItemManager;
        private readonly AboutManager _aboutManager;
        private readonly ModelsManager _modelsManager;
        public AdminController()
        {
            _openPositionManager = new(new EfOpenPositionsRepository(_context));
            _homePageItemManager = new(new EfHomePageItemRepository(_context));
            _aboutManager = new(new EfAboutRepository(_context));
            _modelsManager = new(new EfModelPageItemsRepository(_context));
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            List<About> aboutList = _aboutManager.GetListAll();
            return View(aboutList);
        }
        [HttpPost]
        public ActionResult AboutUs(About about)
        {
            _aboutManager.Add(about);

            List<About> aboutList = _aboutManager.GetListAll();
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
            List<OpenPosition> openPositions = _openPositionManager.GetListAll();

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
        public ActionResult Photos()
        {
            return View();
        }
        public ActionResult Referances()
        {
            return View();
        }
        public ActionResult Videos()
        {
            return View();
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
