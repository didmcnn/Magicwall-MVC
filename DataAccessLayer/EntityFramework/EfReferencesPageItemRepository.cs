using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfReferencesPageItemRepository : EfEntityRepositoryBase<ReferencesPageItem, int, Context>, IReferencesPageItemDal
{
    public EfReferencesPageItemRepository(Context context) : base(context)
    {
    }
}
