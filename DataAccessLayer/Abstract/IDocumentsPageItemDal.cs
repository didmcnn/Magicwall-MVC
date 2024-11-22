using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IDocumentsPageItemDal:IEntityRepository<DocumentsPageItem,int>
{
}
