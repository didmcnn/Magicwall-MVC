using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class PhotoPageItemRepository : IPhotoPageItemDal
{
    Context _context = new ();
    public void Add(PhotoPageItem photoPageItem)
    {
        _context.Add(photoPageItem);
        _context.SaveChanges();
    }

    public void Delete(PhotoPageItem photoPageItem)
    {
        _context.Remove(photoPageItem);
        _context.SaveChanges();
    }

    public List<PhotoPageItem> GetAll()
    {
        return _context.PhotoPageItems.ToList();
    }

    public PhotoPageItem GetById(int id)
    {
        return _context.PhotoPageItems.Find(id)!;
    }

    public void Update(PhotoPageItem photoPageItem)
    {
        _context.Update(photoPageItem);
        _context.SaveChanges();
    }
}

