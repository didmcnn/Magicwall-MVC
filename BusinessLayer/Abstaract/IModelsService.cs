using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract;

public interface IModelsService
{
    void Add(ModelPageItem modelPageItem);

    void Delete(ModelPageItem modelPageItem);
    void Update(ModelPageItem modelPageItem);

    List<ModelPageItem> GetListAll();

    ModelPageItem GetById (int id);
}
