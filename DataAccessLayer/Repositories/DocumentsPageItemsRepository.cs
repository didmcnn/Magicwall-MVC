using System;
using EntityLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;

namespace DataAccessLayer.Repositories;

public class DocumentsPageItemsRepository : IDocumentsPageItemsDal
{
    Context _context = new ();
    public void Add(DocumentsPageItem documentsPageItem)
    {
        _context.Add(documentsPageItem);
        _context.SaveChanges();
    }

    public void Delete(DocumentsPageItem documentsPageItem)
    {
        _context.Remove(documentsPageItem);
        _context.SaveChanges();
    }

    public List<DocumentsPageItem> GetAll()
    {
        return _context.DocumentsPageItems.ToList();
    }

    public DocumentsPageItem GetById(int id)
    {
        return _context.DocumentsPageItems.Find(id)!;
    }

    public List<DocumentsPageItem> GetListAll()
    {
        return _context.DocumentsPageItems.ToList();
    }

    public void Insert(DocumentsPageItem t)
    {
        _context.Add(t);
        _context.SaveChanges();
    }

    public void Update(DocumentsPageItem documentsPageItem)
    {
        _context.Update(documentsPageItem);
        _context.SaveChanges();
    }
}

