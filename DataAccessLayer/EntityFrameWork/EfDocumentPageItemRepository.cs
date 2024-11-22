using System;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFrameWork;

public class EfDocumentPageItemRepository : GenericRepository<DocumentsPageItem>, IDocumentsPageItemsDal
{
    public EfDocumentPageItemRepository(Context context) : base(context)
    {
    }
}
