using CoreLayer.EntityFramework;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract;

public interface IBankAccountDal : IEntityRepository<BankAccount, int>
{
}
