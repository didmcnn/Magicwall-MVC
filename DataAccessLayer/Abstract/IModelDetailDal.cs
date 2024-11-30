using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IModelDetailDal:IEntityRepository<ModelDetail,int>
{
}
