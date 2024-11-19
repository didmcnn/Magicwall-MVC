using System;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class GenericRepository <T> : IGenericDal<T> where T : class 
{
    Context _context = new Context();

    public void Delete(T t)
    {
        _context.Remove(t);
        _context.SaveChanges();
    }

    public T GetById(int id)
    {
        return _context.Set<T>().Find(id)!;
    }

    public List<T> GetListAll()
    {
        return _context.Set<T>().ToList();
    }

    public void Insert(T t)
    {
        _context.Add(t);
        _context.SaveChanges();
    }

    public void Update(T t)
    {
        _context.Update(t);
        _context.SaveChanges();
    }
}
