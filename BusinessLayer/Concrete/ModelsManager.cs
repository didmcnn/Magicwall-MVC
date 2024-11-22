using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using BusinessLayer.Abstaract;

namespace BusinessLayer.Concrete;

public class ModelsManager : IModelsService
{
    IModelPageItemDal _modelPageItemDal;
    public ModelsManager(IModelPageItemDal modelPageItemDal)
    {
        _modelPageItemDal = modelPageItemDal;
    }
    public void Add(ModelPageItem modelPageItem)
    {
        _modelPageItemDal.Insert(modelPageItem);
    }

    public void Delete(ModelPageItem modelPageItem)
    {
        _modelPageItemDal.Delete(modelPageItem);
    }

    public void Update(ModelPageItem modelPageItem)
    {
        _modelPageItemDal.Update(modelPageItem);
    }

    public ModelPageItem GetById(int id)
    {
        return _modelPageItemDal.GetById(id);
    }

    public List<ModelPageItem> GetListAll()
    {
        return _modelPageItemDal.GetListAll();
    }
}
