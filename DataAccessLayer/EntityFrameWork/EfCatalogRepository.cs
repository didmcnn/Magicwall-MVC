using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfCatalogRepository: GenericRepository<Catalog>, ICatalogDal
{

}
