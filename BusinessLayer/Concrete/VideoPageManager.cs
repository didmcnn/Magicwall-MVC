using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Abstract;
using System.Linq.Expressions;
using CoreLayer.Helpers;

namespace BusinessLayer.Concrete;

public class VideoPageManager : IVideoPageItemService
{
    private readonly IVideoPageItemDal _videoPageItemDal;
    public VideoPageManager(IVideoPageItemDal videoPageItemDal)
    {
        _videoPageItemDal = videoPageItemDal;
    }

    public async Task<VideoPageItem> CreateAsync(VideoPageItem t)
    {
        return await _videoPageItemDal.AddAsync(t);
    }


    public async Task<List<VideoPageItem>> GetAllAsync()
    {
        return await _videoPageItemDal.GetAllAsync();
    }

    public async Task<VideoPageItem> GetByFilterAsync(Expression<Func<VideoPageItem, bool>> predicate)
    {
        return await _videoPageItemDal.GetByFilterAsync(predicate);
    }

    public async Task<VideoPageItem> GetByIdAsync(int id)
    {
        return await _videoPageItemDal.GetByIdAsync(id);
    }

    public async Task<VideoPageItem> GetWithIncludeById(int id)
    {
        return await _videoPageItemDal.GetByIdAsync(id);
    }

    public async Task<VideoPageItem> UpdateAsync(VideoPageItem t)
    {
        return await _videoPageItemDal.UpdateAsync(t);
    }
    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _videoPageItemDal.GetByIdAsync(id);
        bool success = FileHelper.DeleteFile(doc.Video, Path.Combine("Files", "VideoPage"));

        if (success)
        {
            return await _videoPageItemDal.DeleteByIdAsync(id);
        }
        else
        {
            return false;
        }
    }
}
