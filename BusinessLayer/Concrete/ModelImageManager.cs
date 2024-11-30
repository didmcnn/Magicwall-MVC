using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete;

public class ModelImageManager : IModelImageService
{
    private readonly IModelImageDal _modelImageDal;
    public ModelImageManager(IModelImageDal modelImageDal)
    {
        _modelImageDal = modelImageDal;
    }

    public async Task<ModelImage> CreateAsync(ModelImage modelImage)
    {
        return await _modelImageDal.AddAsync(modelImage);
    }

    public async Task<List<ModelImage>> CreateListAsync(IFormFile[] modelImages, ModelImageType imageType,int DetailId)
    {
        List<string> filenames = FileHelper.UploadsAsync(Path.Combine("Files", "ModelImages"), modelImages, FileType.image).Result!.Split(",").ToList();

        List<ModelImage> Images = [];

        foreach (var item in filenames)
        {
            Images.Add(new ModelImage()
            {
                ModelDetailId = DetailId,
                Path = item,
                Type = imageType
            });
        }

        return await _modelImageDal.AddListAsync(Images);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _modelImageDal.GetByIdAsync(id);
        bool success = FileHelper.DeleteFile(doc.Path, Path.Combine("Files", "ModelImages"));

        if (success)
        {
            return await _modelImageDal.DeleteByIdAsync(id);
        }
        else
        {
            return false;
        }
    }

    public async Task<List<ModelImage>> GetAllAsync()
    {
        return await _modelImageDal.GetAllAsync();
    }

    public async Task<ModelImage> GetByFilterAsync(Expression<Func<ModelImage, bool>> predicate)
    {
        return await _modelImageDal.GetByFilterAsync(predicate);
    }

    public async Task<ModelImage> GetByIdAsync(int id)
    {
        return await _modelImageDal.GetByIdAsync(id);
    }

    public async Task<ModelImage> UpdateAsync(ModelImage modelImage)
    {
        return await _modelImageDal.UpdateAsync(modelImage);
    }
}
