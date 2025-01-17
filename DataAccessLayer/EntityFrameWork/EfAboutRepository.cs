using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfAboutRepository : EfEntityRepositoryBase<About, int, Context>, IAboutDal
{
    public EfAboutRepository(Context context) : base(context)
    {
    }
}
