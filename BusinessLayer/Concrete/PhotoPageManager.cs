using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;
using System.Linq.Expressions;
using CoreLayer.Helpers;

namespace BusinessLayer.Concrete;

public class PhotoPageManager : IPhotoPageItemService
{
    private readonly IPhotoPageItemDal _photoPageItemDal;
    public PhotoPageManager(IPhotoPageItemDal photoPageItemDal)
    {
        _photoPageItemDal = photoPageItemDal;
    }

    public async Task<PhotoPageItem> CreateAsync(PhotoPageItem t)
    {
        return await _photoPageItemDal.AddAsync(t);
    }

    public async Task<List<PhotoPageItem>> GetAllAsync()
    {
        return await _photoPageItemDal.GetAllAsync();
    }

    public async Task<PhotoPageItem> GetByIdAsync(int id)
    {
        return await _photoPageItemDal.GetByIdAsync(id);
    }

    public async Task<PhotoPageItem> GetWithIncludeById(int id)
    {
        return await _photoPageItemDal.GetByIdAsync(id);
    }

    public async Task<PhotoPageItem> GetByFilterAsync(Expression<Func<PhotoPageItem, bool>> predicate)
    {
        return await _photoPageItemDal.GetByFilterAsync(predicate);
    }

    public async Task<PhotoPageItem> UpdateAsync(PhotoPageItem t)
    {
        return await _photoPageItemDal.UpdateAsync(t);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _photoPageItemDal.GetByIdAsync(id);
        bool success = FileHelper.DeleteFile(doc.Image, Path.Combine("Files", "PhotoPage"));

        if (success)
        {
            return await _photoPageItemDal.DeleteByIdAsync(id);
        }
        else
        {
            return false;

        }
    }
}

