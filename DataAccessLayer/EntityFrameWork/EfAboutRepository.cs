using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfAboutRepository : GenericRepository<About>, IAboutDal
{
    public EfAboutRepository(Context context) : base(context)
    {
    }
}
