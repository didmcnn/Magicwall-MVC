using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace Magicwall.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepository());
        // GET: AboutController
        public ActionResult Index()
        {
            var values = aboutManager.GetListAll();
            return View(values);
        }

    }
}
