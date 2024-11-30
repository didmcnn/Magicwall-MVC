using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    public class EfModelDetailRepository:EfEntityRepositoryBase<ModelDetail,int,Context>,IModelDetailDal
    {
        public EfModelDetailRepository(Context context):base(context)
        {
            
        }
    }
}
