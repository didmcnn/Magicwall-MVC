using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface ICatalogDal : IEntityRepository<Catalog, int>
{
}
