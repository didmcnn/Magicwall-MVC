using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class ContactRepository : IContactDal
{
    Context _context = new ();
    public void Add(Contact contact)
    {
        _context.Add(contact);
        _context.SaveChanges();
    }

    public void Delete(Contact contact)
    {
        _context.Remove(contact);
        _context.SaveChanges();
    }

    public List<Contact> GetAll()
    {
            return _context.Contacts.ToList();
    }

    public Contact GetById(int id)
    {
            return _context.Contacts.Find(id)!;
    }

    public List<Contact> GetListAll()
    {
        return _context.Contacts.ToList();
    }

    public void Insert(Contact t)
    {
        _context.Add(t);
        _context.SaveChanges();
    }

    public void Update(Contact contact)
    {
        _context.Update(contact);
        _context.SaveChanges();
    }
}

