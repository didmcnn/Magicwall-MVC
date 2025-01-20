using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using System.Linq.Expressions;

namespace BusinessLayer.Abstract;

public interface IModelDetailService
{
    Task<ModelDetail> CreateAsync(ModelDetail modelDetail);
    Task<List<ModelDetail>> GetAllAsync();
    Task<ModelDetail> GetByIdAsync(int id);
    Task<ModelDetail> GetWithIncludeById(int id);
    Task<ModelDetail> GetByFilterAsync(Expression<Func<ModelDetail, bool>> predicate);
    Task<ModelDetail> UpdateAsync(ModelDetail modelDetail);
    Task<bool> DeleteAsync(int id);
    Task<ModelDetail> AddModelZipAsync(IFormFile DetailZipFiles, int DetailId);
    Task<bool> DeleteModelZipAsync(int id);
}
