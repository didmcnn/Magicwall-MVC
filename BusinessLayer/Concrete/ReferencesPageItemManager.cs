using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete;

internal class ReferencesPageItemManager : IReferencesPageItemService
{
    private readonly IReferencesPageItemDal _referencesPageItemDal;
    public ReferencesPageItemManager(IReferencesPageItemDal referencesPageItemDal)
    {
        _referencesPageItemDal = referencesPageItemDal;
    }
    public async Task<ReferencesPageItem> CreateAsync(ReferencesPageItem t)
    {
        return await _referencesPageItemDal.AddAsync(t);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _referencesPageItemDal.GetByIdAsync(id);
        bool success = FileHelper.DeleteFile(doc.Image, Path.Combine("Files", "ReferencesPage"));

        if (success)
        {
            return await _referencesPageItemDal.DeleteByIdAsync(id);
        }
        else
        {
            return false;
        }
        return await _referencesPageItemDal.DeleteByIdAsync(id);
    }

    public async Task<List<ReferencesPageItem>> GetAllAsync()
    {
        return await _referencesPageItemDal.GetAllAsync();
    }

    public async Task<ReferencesPageItem> GetByFilterAsync(Expression<Func<ReferencesPageItem, bool>> predicate)
    {
        return await _referencesPageItemDal.GetByFilterAsync(predicate);
    }

    public async Task<ReferencesPageItem> GetByIdAsync(int id)
    {
        return await _referencesPageItemDal.GetByIdAsync(id);
    }

    public Task<ReferencesPageItem> GetWithIncludeById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ReferencesPageItem> UpdateAsync(ReferencesPageItem t)
    {
        return await _referencesPageItemDal.UpdateAsync(t);
    }
}
