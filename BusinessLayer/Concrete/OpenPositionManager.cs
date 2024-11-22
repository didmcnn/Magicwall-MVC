using System.Linq.Expressions;
using BusinessLayer.Abstaract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete;

    public class OpenPositionManager : IOpenPositionService
    {
        private readonly IOpenPositionDal _openPositionDal;
        public OpenPositionManager(IOpenPositionDal openPositionDal)
        {
            _openPositionDal = openPositionDal;
        }

        public async Task<OpenPosition> CreateAsync(OpenPosition t)
        {
            return await _openPositionDal.AddAsync(t);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _openPositionDal.DeleteByIdAsync(id);
        }

        public async Task<List<OpenPosition>> GetAllAsync()
        {
            return await _openPositionDal.GetAllAsync();
        }

        public async Task<OpenPosition> GetByFilterAsync(Expression<Func<OpenPosition, bool>> predicate)
        {
            return await _openPositionDal.GetByFilterAsync(predicate);
        }

        public async Task<OpenPosition> GetByIdAsync(int id)
        {
            return await _openPositionDal.GetByIdAsync(id);
        }

        public async Task<OpenPosition> GetWithIncludeById(int id)
        {
            return await _openPositionDal.GetByIdAsync(id);
        }

        public async Task<OpenPosition> UpdateAsync(OpenPosition t)
        {
            return await _openPositionDal.UpdateAsync(t);
        }
    }

