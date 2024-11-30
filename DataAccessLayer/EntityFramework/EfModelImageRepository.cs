using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework
{
    internal class EfModelImageRepository:EfEntityRepositoryBase<ModelImage,int,Context>,IModelImageDal
    {
        public EfModelImageRepository(Context context):base(context)
        {
            
        }
    }
}
