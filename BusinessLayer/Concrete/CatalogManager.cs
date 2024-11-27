using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete;

public class CatalogManager : ICatalogService
{
    private readonly ICatalogDal _catalogDal;
    public CatalogManager(ICatalogDal catalogDal)
    {
        _catalogDal = catalogDal;
    }

    public async Task<Catalog> CreateAsync(Catalog catalog)
    {
        return await _catalogDal.AddAsync(catalog);
    }

    public async Task<List<Catalog>> GetAllAsync()
    {
        return await _catalogDal.GetAllAsync();
    }

    public async Task<Catalog> GetByIdAsync(int id)
    {
        return await _catalogDal.GetByIdAsync(id);
    }

    public async Task<Catalog> GetWithIncludeById(int id)
    {
        return await _catalogDal.GetByIdAsync(id);
    }

    public async Task<Catalog> GetByFilterAsync(Expression<Func<Catalog, bool>> predicate)
    {
        return await _catalogDal.GetByFilterAsync(predicate);
    }

    public async Task<Catalog> UpdateAsync(Catalog catalog)
    {
        return await _catalogDal.UpdateAsync(catalog);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _catalogDal.GetByIdAsync(id);
        bool success = false;
        if (!string.IsNullOrEmpty(doc.PDF))
        {
            success = FileHelper.DeleteFile(doc.PDF, Path.Combine("Files", "Catalog"));
        }
        else
        {
            success = true;
        }

        if (success)
        {
            return await _catalogDal.DeleteByIdAsync(id);
        }
        else
        {
            return false;
        }
    }
}
