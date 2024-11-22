using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Abstaract;

namespace BusinessLayer.Concrete;

public class VideoPageManager : IVideoPageItemService
{
    IVideoPageItemDal _videoPageItemDal;
    public VideoPageManager(IVideoPageItemDal videoPageItemDal)
    {
        _videoPageItemDal = videoPageItemDal;
    }
    public void Add(VideoPageItem videoPageItem)
    {
        _videoPageItemDal.Insert(videoPageItem);
    }

    public void Delete(VideoPageItem videoPageItem)
    {
        _videoPageItemDal.Delete(videoPageItem);
    }

    public void Update(VideoPageItem videoPageItem)
    {
        _videoPageItemDal.Update(videoPageItem);
    }

    public VideoPageItem GetById(int id)
    {
        return _videoPageItemDal.GetById(id);
    }

    public List<VideoPageItem> GetListAll()
    {
        return _videoPageItemDal.GetListAll();
    }
}
