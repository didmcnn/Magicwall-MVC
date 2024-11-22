using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfContactRepository : GenericRepository<Contact>, IContactDal
{
    public EfContactRepository(Context context) : base(context)
    {
    }
}
