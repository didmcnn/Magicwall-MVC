using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class CatalogRepository : ICatalogDal
{
    Context _context = new ();
    public void Add(Catalog catalog)
    {
        _context.Add(catalog);
        _context.SaveChanges();
    }

        public void Delete(Catalog catalog)
    {
        _context.Remove(catalog);
        _context.SaveChanges();
    }

    public List<Catalog> GetAll()
    {
        return _context.Catalogs.ToList();
    }

    public Catalog GetById(int id)
    {
            return _context.Catalogs.Find(id)!;
    }

    public List<Catalog> GetListAll()
    {
        return _context.Catalogs.ToList();
    }

    public void Insert(Catalog t)
    {
        _context.Add(t);
        _context.SaveChanges();
    }

    public void Update(Catalog catalog)
    {
        _context.Update(catalog);
        _context.SaveChanges();
    }
}

