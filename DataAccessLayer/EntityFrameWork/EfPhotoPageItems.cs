using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfPhotoPageItemsRepository : GenericRepository<PhotoPageItem>, IPhotoPageItemDal
{
    public EfPhotoPageItemsRepository(Context context) : base(context)
    {
    }
}
