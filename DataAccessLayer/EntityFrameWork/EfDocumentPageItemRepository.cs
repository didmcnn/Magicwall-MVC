using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfDocumentPageItemRepository : EfEntityRepositoryBase<DocumentsPageItem,int,Context>, IDocumentsPageItemDal
{
    public EfDocumentPageItemRepository(Context context) : base(context)
    {
    }
}
