using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfPhotoPageItemRepository : EfEntityRepositoryBase<PhotoPageItem, int, Context>, IPhotoPageItemDal
{
    public EfPhotoPageItemRepository(Context context) : base(context)
    {
    }
}
