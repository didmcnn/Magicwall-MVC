using EntityLayer.Concrete;

namespace BusinessLayer.Abstract;

public interface IPhotoPageItemService:IGenericService<PhotoPageItem>
{
    Task<List<PhotoPageItem>> GetAllDecorationAsync();
    Task<List<PhotoPageItem>> GetAllSignAsync();
}
