using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete;

public class AboutManager : IAboutService
{
    private readonly IAboutDal _aboutDal;
    public AboutManager(IAboutDal aboutDal)
    {
        _aboutDal = aboutDal;
    }

    public async Task<About> CreateAsync(About about)
    {
        return await _aboutDal.AddAsync(about);
    }

    public async Task<List<About>> GetAllAsync()
    {
        return await _aboutDal.GetAllAsync();
    }

    public async Task<About> GetByIdAsync(int id)
    {
        return await _aboutDal.GetByIdAsync(id);
    }

    public async Task<About> GetWithIncludeById(int id)
    {
        return await _aboutDal.GetByIdAsync(id);
    }

    public async Task<About> GetByFilterAsync(Expression<Func<About, bool>> predicate)
    {
        return await _aboutDal.GetByFilterAsync(predicate);
    }

    public async Task<About> UpdateAsync(About about)
    {
        var existItem = await GetByIdAsync(about.Id);

        if (existItem != null && about.Image != null && existItem.Image != null)
        {
            FileHelper.DeleteFile(existItem.Image, Path.Combine("Files", "AboutUs"));
        }
        else if (existItem != null && about.Image == null)
        {
            about.Image = existItem.Image;
        }

        return await _aboutDal.UpdateAsync(about);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var doc = await _aboutDal.GetByIdAsync(id);
        bool success = false;
        if (!string.IsNullOrEmpty(doc.Image))
        {
            success = FileHelper.DeleteFile(doc.Image, Path.Combine("Files", "AboutUs"));
        }
        else
        {
            success = true;
        }

        if (success)
        {
            return await _aboutDal.DeleteByIdAsync(id);
        }
        else
        {
            return false;
        }
    }
}
