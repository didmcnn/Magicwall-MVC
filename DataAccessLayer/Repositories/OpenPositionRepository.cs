using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class OpenPositionRepository : IOpenPositionDal
{
    Context _context = new ();
    public void Add(OpenPosition openPosition)
    {
        _context.Add(openPosition);
        _context.SaveChanges();
    }

    public void Delete(OpenPosition openPosition)
    {
        _context.Remove(openPosition);
        _context.SaveChanges();
    }

    public List<OpenPosition> GetAll()
    {
        return _context.OpenPositions.ToList();
    }

    public OpenPosition GetById(int id)
    {
        return _context.OpenPositions.Find(id)!;
    }

    public void Update(OpenPosition openPosition)
    {
        _context.Update(openPosition);
        _context.SaveChanges();
    }
}

