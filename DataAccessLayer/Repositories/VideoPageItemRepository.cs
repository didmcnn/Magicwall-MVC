using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class VideoPageItemRepository : IVideoPageItemDal
{
    Context _context = new ();
    public void Add(VideoPageItem videoPageItem)
    {
        _context.Add(videoPageItem);
        _context.SaveChanges();
    }

        public void Delete(VideoPageItem videoPageItem)
    {
        _context.Remove(videoPageItem);
        _context.SaveChanges();
    }

    public List<VideoPageItem> GetAll()
    {
            return _context.VideoPageItems.ToList();
    }

    public VideoPageItem GetById(int id)
    {
            return _context.VideoPageItems.Find(id)!;
    }

    public void Update(VideoPageItem videoPageItem)
    {
        _context.Update(videoPageItem);
        _context.SaveChanges();
    }
}

