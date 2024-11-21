using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract;

public interface IHomePageItemService
{
    void Add(HomePageItem homePageItem);

    void Delete(HomePageItem homePageItem);
    void Update(HomePageItem homePageItem);

    List<HomePageItem> GetListAll();

    HomePageItem GetById (int id);
}
