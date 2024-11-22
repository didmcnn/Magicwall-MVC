using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Abstaract;

namespace BusinessLayer.Concrete;

public class PhotoPageManager : IPhotoPageItemService
{
    IPhotoPageItemDal _photoPageItemDal;
    public PhotoPageManager(IPhotoPageItemDal photoPageItemDal)
    {
        _photoPageItemDal = photoPageItemDal;
    }
    public void Add(PhotoPageItem photoPageItem)
    {
        _photoPageItemDal.Insert(photoPageItem);
    }

    public void Delete(PhotoPageItem photoPageItem)
    {
        _photoPageItemDal.Delete(photoPageItem);
    }

    public void Update(PhotoPageItem photoPageItem)
    {
        _photoPageItemDal.Update(photoPageItem);
    }

    public PhotoPageItem GetById(int id)
    {
        return _photoPageItemDal.GetById(id);
    }

    public List<PhotoPageItem> GetListAll()
    {
        return _photoPageItemDal.GetListAll();
    }
}
