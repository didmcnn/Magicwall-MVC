using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework;

public class EfUserRepository : EfEntityRepositoryBase<User, int, Context>, IUserDal
{
    public EfUserRepository(Context context) : base(context)
    {
    }
}
