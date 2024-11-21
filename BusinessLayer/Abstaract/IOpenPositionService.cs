using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract
{
    public interface IOpenPositionService
    {
        void Add(OpenPosition op);

        void Delete(OpenPosition op);
        void Update(OpenPosition op);

        List<OpenPosition> GetListAll();

        OpenPosition GetById(int id);
    }
}
