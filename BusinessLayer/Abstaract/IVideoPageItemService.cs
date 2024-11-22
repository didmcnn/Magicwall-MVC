using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract
{
    public interface IVideoPageItemService
    {
        void Add(VideoPageItem videoPageItem);

        void Delete(VideoPageItem videoPageItem);
        void Update(VideoPageItem videoPageItem);

        List<VideoPageItem> GetListAll();

        VideoPageItem GetById(int id);
    }
}
