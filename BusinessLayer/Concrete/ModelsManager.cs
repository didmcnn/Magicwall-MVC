using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete;

public class ModelsManager : IModelsService
{
    IModelPageItemDal _modelPageItemDal;
    IModelDetailService _modelDetailService;
    public ModelsManager(IModelPageItemDal modelPageItemDal, IModelDetailService modelDetailService)
    {
        _modelPageItemDal = modelPageItemDal;
        _modelDetailService = modelDetailService;
    }

    public async Task<ModelPageItem> CreateAsync(ModelPageItem t)
    {
        return await _modelPageItemDal.AddAsync(t);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _modelPageItemDal.GetByIdAsync(id);
        bool success = FileHelper.DeleteFile(doc.Image, Path.Combine("Files", "Models"));

        if (doc.DetailsId != null)
        {
            var detail = await _modelDetailService.GetWithIncludeById((int)doc.DetailsId);
            if (detail.ModelImages != null)
            {
                List<string> images = [];
                try
                {
                    foreach (var image in detail.ModelImages) { images.Add(image.Path); }
                    FileHelper.DeleteListFiles(images, Path.Combine("Files", "ModelImages"));
                }
                catch (Exception)
                {
                    success = false;
                }
            }
        }
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

    public async Task<ModelPageItem> GetWithIncludeById(int id)
    {
        return await _modelPageItemDal.GetByFilterAsync(x => x.Id == id, x => x.Include(x => x.Details).ThenInclude(x => x.ModelImages));
    }

    public async Task<ModelPageItem> UpdateAsync(ModelPageItem t)
    {
        return await _modelPageItemDal.UpdateAsync(t);
    }
}
