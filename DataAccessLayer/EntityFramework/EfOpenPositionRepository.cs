using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfOpenPositionRepository : EfEntityRepositoryBase<OpenPosition, int, Context>, IOpenPositionDal
{
    public EfOpenPositionRepository(Context context) : base(context)
    {
    }
}
