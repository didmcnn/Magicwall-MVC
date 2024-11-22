using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfOpenPositionsRepository : GenericRepository<OpenPosition>, IOpenPositionDal
{
    public EfOpenPositionsRepository(Context context) : base(context)
    {
    }
}
