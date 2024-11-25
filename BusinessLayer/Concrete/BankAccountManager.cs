using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete;

public class BankAccountManager : IBankAccountService
{
    private readonly IBankAccountDal _bankAccountDal;    
    public BankAccountManager(IBankAccountDal bankAccountDal)
    {
        _bankAccountDal = bankAccountDal;
    }

    public async Task<BankAccount> CreateAsync(BankAccount bankAccount)
    {
        return await _bankAccountDal.AddAsync(bankAccount);
    }

    public async Task<List<BankAccount>> GetAllAsync()
    {
        return await _bankAccountDal.GetAllAsync();
    }

    public async Task<BankAccount> GetByIdAsync(int id)
    {
        return await _bankAccountDal.GetByIdAsync(id);
    }

    public async Task<BankAccount> GetWithIncludeById(int id)
    {
        return await _bankAccountDal.GetByIdAsync(id);
    }

    public async Task<BankAccount> GetByFilterAsync(Expression<Func<BankAccount, bool>> predicate)
    {
        return await _bankAccountDal.GetByFilterAsync(predicate);
    }

    public async Task<BankAccount> UpdateAsync(BankAccount bankAccount)
    {
        return await _bankAccountDal.UpdateAsync(bankAccount);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var bankAccount = await _bankAccountDal.GetByIdAsync(id);
        bool success = FileHelper.DeleteFile(bankAccount.Image, Path.Combine("Files", "BankAccount"));

        if (success)
        {
            return await _bankAccountDal.DeleteByIdAsync(id);
        }
        else
        {
            return false;
        }
    }
}
