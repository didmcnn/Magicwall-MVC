using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IHomePageItemDal:IEntityRepository<HomePageItem,int>
{
}
