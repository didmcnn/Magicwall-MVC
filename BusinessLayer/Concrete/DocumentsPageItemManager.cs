using System;
using System.Linq.Expressions;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Abstaract;

namespace BusinessLayer.Concrete;

public class DocumentsPageItemManager : IDocumentsPageItemService
{
    private readonly IDocumentsPageItemDal _documentsPageItemDal;
    
    public DocumentsPageItemManager(IDocumentsPageItemDal documentsPageItemDal)
    {
        _documentsPageItemDal = documentsPageItemDal;
    }

    public async Task<DocumentsPageItem> CreateAsync(DocumentsPageItem documentsPageItem)
    {
        return await _documentsPageItemDal.AddAsync(documentsPageItem);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _documentsPageItemDal.DeleteByIdAsync(id);
    }

    public async Task<List<DocumentsPageItem>> GetAllAsync()
    {
        return await _documentsPageItemDal.GetAllAsync();
    }

    public async Task<DocumentsPageItem> GetByFilterAsync(Expression<Func<DocumentsPageItem, bool>> predicate)
    {
        return await _documentsPageItemDal.GetByFilterAsync(predicate);
    }

    public async Task<DocumentsPageItem> GetByIdAsync(int id)
    {
        return await _documentsPageItemDal.GetByIdAsync(id);
    }

    public async Task<DocumentsPageItem> GetWithIncludeById(int id)
    {
        return await _documentsPageItemDal.GetByIdAsync(id);
    }

    public async Task<DocumentsPageItem> UpdateAsync(DocumentsPageItem documentsPageItem)
    {
        return await _documentsPageItemDal.UpdateAsync(documentsPageItem);
    }
}
