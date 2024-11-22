using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IPhotoPageItemDal : IEntityRepository<PhotoPageItem, int>
{
}
