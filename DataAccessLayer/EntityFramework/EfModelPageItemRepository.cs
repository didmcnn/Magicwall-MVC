using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfModelPageItemRepository : EfEntityRepositoryBase<ModelPageItem, int, Context>, IModelPageItemDal
{
    public EfModelPageItemRepository(Context context) : base(context)
    {
    }
}
