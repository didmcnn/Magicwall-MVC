using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class BankAccountRepository : IBankAccountDal
{
    Context _context = new ();
    public void Add(BankAccount bankAccount)
    {
        _context.Add(bankAccount);
        _context.SaveChanges();
    }

    public void Delete(BankAccount bankAccount)
    {
        _context.Remove(bankAccount);
        _context.SaveChanges();
    }

    public List<BankAccount> GetAll()
    {
        return _context.BankAccounts.ToList();
    }

    public BankAccount GetById(int id)
    {
        return _context.BankAccounts.Find(id)!;
    }

    public void Update(BankAccount bankAccount)
    {
        _context.Update(bankAccount);
        _context.SaveChanges();
    }
}

