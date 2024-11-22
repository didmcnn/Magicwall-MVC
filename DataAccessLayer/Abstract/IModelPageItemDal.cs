using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IModelPageItemDal : IEntityRepository<ModelPageItem, int>
{
}
