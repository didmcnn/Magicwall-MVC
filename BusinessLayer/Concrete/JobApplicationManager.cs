using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class JobApplicationManager : IJobApplicationService
    {
        private readonly IJobApplicationDal _jobApplicationDal;
        public JobApplicationManager(IJobApplicationDal jobApplicationDal)
        {
            _jobApplicationDal = jobApplicationDal;
        }

        public async Task<JobApplication> CreateAsync(JobApplication t)
        {
            return await _jobApplicationDal.AddAsync(t);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _jobApplicationDal.DeleteByIdAsync(id);
        }

        public async Task<List<JobApplication>> GetAllAsync()
        {
            return await _jobApplicationDal.GetAllAsync();
        }

        public async Task<JobApplication> GetByFilterAsync(Expression<Func<JobApplication, bool>> predicate)
        {
            return await _jobApplicationDal.GetByFilterAsync(predicate);
        }

        public async Task<JobApplication> GetByIdAsync(int id)
        {
            return await _jobApplicationDal.GetByIdAsync(id);
        }

        public Task<JobApplication> GetWithIncludeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<JobApplication> UpdateAsync(JobApplication t)
        {
            return await _jobApplicationDal.UpdateAsync(t);
        }
    }
}
