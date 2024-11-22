using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfHomePageItemRepository : GenericRepository<HomePageItem>, IHomePageItemDal
{
    public EfHomePageItemRepository(Context context) : base(context)
    {
    }
}
