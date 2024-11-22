using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Abstaract;
using System.Linq.Expressions;

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
        return await _modelPageItemDal.DeleteByIdAsync(id);
    }

    public Task<List<ModelPageItem>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ModelPageItem> GetByFilterAsync(Expression<Func<ModelPageItem, bool>> predicate)
    {
        throw new NotImplementedException();
    }

    public Task<ModelPageItem> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ModelPageItem> GetWithIncludeById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ModelPageItem> UpdateAsync(ModelPageItem t)
    {
        throw new NotImplementedException();
    }
}
