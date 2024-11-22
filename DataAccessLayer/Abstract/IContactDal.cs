using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IContactDal:IEntityRepository<Contact,int>
{
}
