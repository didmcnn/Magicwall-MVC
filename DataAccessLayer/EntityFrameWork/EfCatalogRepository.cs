using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfCatalogRepository : EfEntityRepositoryBase<Catalog, int, Context>, ICatalogDal
{
    public EfCatalogRepository(Context context) : base(context)
    {
    }
}
