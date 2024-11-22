using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IReferencesPageItemDal : IEntityRepository<ReferencesPageItem, int>
{
}
