using EntityLayer.Concrete;
using EntityLayer.Enums;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract;

public interface IModelImageService
{
    Task<ModelImage> CreateAsync(ModelImage modelImage);
    Task<List<ModelImage>> CreateListAsync(IFormFile[] modelImages, ModelImageType imageType,int DetailId);
    Task<List<ModelImage>> GetAllAsync();
    Task<ModelImage> GetByIdAsync(int id);
    Task<ModelImage> GetByFilterAsync(Expression<Func<ModelImage, bool>> predicate);
    Task<ModelImage> UpdateAsync(ModelImage modelImage);
    Task<bool> DeleteAsync(int id);
}
