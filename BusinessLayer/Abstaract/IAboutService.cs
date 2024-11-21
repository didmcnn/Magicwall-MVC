using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract;

public interface IAboutService
{
    void Add(About about);

    void Delete(About about);
    void Update(About about);

    List<About> GetListAll();

    About GetById (int id);
}
