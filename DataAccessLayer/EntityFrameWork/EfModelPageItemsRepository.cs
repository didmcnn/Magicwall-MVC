using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfModelPageItemsRepository: GenericRepository<ModelPageItem>, IModelPageItemDal
{

}
