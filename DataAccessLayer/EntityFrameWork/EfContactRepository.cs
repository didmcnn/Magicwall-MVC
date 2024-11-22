using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfContactRepository : EfEntityRepositoryBase<Contact,int,Context>, IContactDal
{
    public EfContactRepository(Context context) : base(context)
    {
    }
}
