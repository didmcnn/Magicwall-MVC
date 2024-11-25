using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;
using System.Linq.Expressions;
using CoreLayer.Helpers;

namespace BusinessLayer.Concrete;

public class ModelsManager : IModelsService
{
    IModelPageItemDal _modelPageItemDal;
    public ModelsManager(IModelPageItemDal modelPageItemDal)
    {
        _modelPageItemDal = modelPageItemDal;
    }

    public async Task<ModelPageItem> CreateAsync(ModelPageItem t)
    {
        return await _modelPageItemDal.AddAsync(t);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _modelPageItemDal.GetByIdAsync(id);
        bool success = FileHelper.DeleteFile(doc.Image, Path.Combine("Files", "Models"));

        if (success)
        {
            return await _modelPageItemDal.DeleteByIdAsync(id);
        }
        else
        {
            return false;
        }
    }

    public async Task<List<ModelPageItem>> GetAllAsync()
    {
        return await _modelPageItemDal.GetAllAsync();
    }

    public async Task<ModelPageItem> GetByFilterAsync(Expression<Func<ModelPageItem, bool>> predicate)
    {
        return await _modelPageItemDal.GetByFilterAsync(predicate);
    }

    public async Task<ModelPageItem> GetByIdAsync(int id)
    {
        return await _modelPageItemDal.GetByIdAsync(id);
    }

    public Task<ModelPageItem> GetWithIncludeById(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<ModelPageItem> UpdateAsync(ModelPageItem t)
    {
        return await _modelPageItemDal.UpdateAsync(t);
    }
}
