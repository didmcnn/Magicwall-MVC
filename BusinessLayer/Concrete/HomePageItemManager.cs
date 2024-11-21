using BusinessLayer.Abstaract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class HomePageItemManager : IHomePageItemService
    {
        private readonly IHomePageItemDal _homePageItemDal;
        public HomePageItemManager(IHomePageItemDal homePageItemDal)
        {
            _homePageItemDal = homePageItemDal;
        }

        public void Add(HomePageItem homePageItem)
        {
            _homePageItemDal.Insert(homePageItem);
        }

        public void Delete(HomePageItem homePageItem)
        {
            _homePageItemDal.Delete(homePageItem);
        }

        public HomePageItem GetById(int id)
        {
            return _homePageItemDal.GetById(id);
        }

        public List<HomePageItem> GetListAll()
        {
            return _homePageItemDal.GetListAll();
        }

        public void Update(HomePageItem homePageItem)
        {
            _homePageItemDal.Update(homePageItem);
        }
    }
}
