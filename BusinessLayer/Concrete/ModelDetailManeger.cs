using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class ModelDetailManeger : IModelDetailService
    {
        private readonly IModelDetailDal _modelDetailDal;
        public ModelDetailManeger(IModelDetailDal modelDetailDal)
        {
            _modelDetailDal = modelDetailDal;
        }
        public async Task<ModelDetail> CreateAsync(ModelDetail modelDetail)
        {
            return await _modelDetailDal.AddAsync(modelDetail);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _modelDetailDal.DeleteByIdAsync(id);
        }

        public async Task<List<ModelDetail>> GetAllAsync()
        {
            return await _modelDetailDal.GetAllAsync();
        }

        public async Task<ModelDetail> GetByFilterAsync(Expression<Func<ModelDetail, bool>> predicate)
        {
            return await _modelDetailDal.GetByFilterAsync(predicate);
        }

        public async Task<ModelDetail> GetByIdAsync(int id)
        {
            return await _modelDetailDal.GetByIdAsync(id);
        }

        public async Task<ModelDetail> GetWithIncludeById(int id)
        {
            return await _modelDetailDal.GetByFilterAsync(x => x.Id == id, x => x.Include(x => x.ModelImages));
        }

        public async Task<ModelDetail> UpdateAsync(ModelDetail modelDetail)
        {
            return await _modelDetailDal.UpdateAsync(modelDetail);
        }
    }
}
