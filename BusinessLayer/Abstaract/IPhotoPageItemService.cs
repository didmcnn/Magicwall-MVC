using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract
{
    public interface IPhotoPageItemService
    {
        void Add(PhotoPageItem photoPageItem);

        void Delete(PhotoPageItem photoPageItem);
        void Update(PhotoPageItem photoPageItem);

        List<PhotoPageItem> GetListAll();

        PhotoPageItem GetById(int id);
    }
}
