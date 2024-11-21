using BusinessLayer.Abstaract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Magicwall.Controllers
{
    public class AdminController : Controller
    {
        private readonly OpenPositionManager _openPositionManager = new(new EfOpenPositionsRepository());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AboutUs()
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
            return View();
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
    }
}
