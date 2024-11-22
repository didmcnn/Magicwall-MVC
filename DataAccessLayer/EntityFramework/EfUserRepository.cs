using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfUserRepository : EfEntityRepositoryBase<User, int, Context>, IUserDal
{
    public EfUserRepository(Context context) : base(context)
    {
    }
}
