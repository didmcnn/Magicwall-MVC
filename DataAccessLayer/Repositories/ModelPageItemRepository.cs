using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class ModelPageItemRepository : IModelPageItemDal
{
    Context _context = new ();
    public void Add(ModelPageItem modelPageItem)
    {
        _context.Add(modelPageItem);
        _context.SaveChanges();
    }

    public void Delete(ModelPageItem modelPageItem)
    {
        _context.Remove(modelPageItem);
        _context.SaveChanges();
    }

    public List<ModelPageItem> GetAll()
    {
        return _context.ModelPageItems.ToList();
    }

    public ModelPageItem GetById(int id)
    {
        return _context.ModelPageItems.Find(id)!;
    }

    public void Update(ModelPageItem modelPageItem)
    {
        _context.Update(modelPageItem);
        _context.SaveChanges();
    }
}

