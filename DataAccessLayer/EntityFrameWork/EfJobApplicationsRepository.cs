using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfJobApplicationsRepository: GenericRepository<JobApplication>, IJobApplicationDal
{

}
