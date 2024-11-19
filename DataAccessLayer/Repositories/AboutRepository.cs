using System;
using DataAccessLayer.Abstract;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class AboutRepository : IAboutDal
{
    Context _context = new Context();
    public void Add(About about)
    {
        _context.Add(about);
        _context.SaveChanges();
    }

    public void Delete(About about)
    {
        _context.Remove(about);
        _context.SaveChanges();
    }

    public List<About> GetAll()
    {
        return _context.Abouts.ToList();
    }

    public About GetById(int id)
    {
        return _context.Abouts.Find(id);
    }

    public void Update(About about)
    {
        _context.Update(about);
        _context.SaveChanges();
    }
    
}
