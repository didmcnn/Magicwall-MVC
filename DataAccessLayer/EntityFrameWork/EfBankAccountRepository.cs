using CoreLayer.EntityFramework;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.EntityFramework;

public class EfBankAccountRepository : EfEntityRepositoryBase<BankAccount, int, Context>, IBankAccountDal
{
    public EfBankAccountRepository(Context context) : base(context)
    {
    }
}
