using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfJobApplicationRepository : EfEntityRepositoryBase<JobApplication, int, Context>, IJobApplicationDal
{
    public EfJobApplicationRepository(Context context) : base(context)
    {
    }
}
