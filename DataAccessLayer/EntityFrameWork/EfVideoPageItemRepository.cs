using System;
using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfVideoPageItemRepository : EfEntityRepositoryBase<VideoPageItem,int,Context>, IVideoPageItemDal
{
    public EfVideoPageItemRepository(Context context) : base(context)
    {
    }
}
