using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfHomePageItemRepository : EfEntityRepositoryBase<HomePageItem,int,Context>, IHomePageItemDal
{
    public EfHomePageItemRepository(Context context) : base(context)
    {
    }
}
