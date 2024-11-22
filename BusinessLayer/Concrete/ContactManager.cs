using BusinessLayer.Abstaract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;
        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            return await _contactDal.AddAsync(contact);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _contactDal.DeleteByIdAsync(id);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await _contactDal.GetAllAsync();
        }

        public async Task<Contact> GetByFilterAsync(Expression<Func<Contact, bool>> predicate)
        {
            return await _contactDal.GetByFilterAsync(predicate);
        }

        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _contactDal.GetByIdAsync(id);
        }

        public async Task<Contact> GetWithIncludeById(int id)
        {
            return await _contactDal.GetByIdAsync(id);
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            return await _contactDal.UpdateAsync(contact);
        }
    }
}
