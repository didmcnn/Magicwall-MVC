using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class ReferencesPageItemRepository : IReferencesPageItemDal
{
    Context _context = new ();
    public void Add(ReferencesPageItem referencesPageItem)
    {
        _context.Add(referencesPageItem);
        _context.SaveChanges();
    }

    public void Delete(ReferencesPageItem referencesPageItem)
    {
        _context.Remove(referencesPageItem);
        _context.SaveChanges();
    }

    public List<ReferencesPageItem> GetAll()
    {
        return _context.ReferencesPageItems.ToList();
    }

    public ReferencesPageItem GetById(int id)
    {
        return _context.ReferencesPageItems.Find(id)!;
    }

    public List<ReferencesPageItem> GetListAll()
    {
        return _context.ReferencesPageItems.ToList();
    }

    public void Insert(ReferencesPageItem t)
    {
        _context.Add(t);
        _context.SaveChanges();
    }

    public void Update(ReferencesPageItem referencesPageItem)
    {
        _context.Update(referencesPageItem);
        _context.SaveChanges();
    }
}

