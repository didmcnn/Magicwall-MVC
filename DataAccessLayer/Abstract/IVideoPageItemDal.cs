using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IVideoPageItemDal : IEntityRepository<VideoPageItem, int>
{
}
