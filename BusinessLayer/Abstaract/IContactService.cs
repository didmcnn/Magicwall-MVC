using EntityLayer.Concrete;

namespace BusinessLayer.Abstaract;

public interface IContactService
{
    void Add(Contact contact);

    void Delete(Contact contact);
    void Update(Contact contact);

    List<Contact> GetListAll();

    Contact GetById (int id);
}
