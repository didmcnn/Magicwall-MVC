using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IJobApplicationDal:IEntityRepository<JobApplication,int>
{
}
