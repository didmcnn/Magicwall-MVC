using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IModelImageDal:IEntityRepository<ModelImage,int>
{
}
