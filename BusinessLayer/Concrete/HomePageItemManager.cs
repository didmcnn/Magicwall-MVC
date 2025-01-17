using BusinessLayer.Abstract;
using CoreLayer.Helpers;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Linq.Expressions;

namespace BusinessLayer.Concrete
{
    public class HomePageItemManager : IHomePageItemService
    {
        private readonly IHomePageItemDal _homePageItemDal;
        public HomePageItemManager(IHomePageItemDal homePageItemDal)
        {
            _homePageItemDal = homePageItemDal;
        }

        public async Task<HomePageItem> CreateAsync(HomePageItem t)
        {
            return await _homePageItemDal.AddAsync(t);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var bankAccount = await _homePageItemDal.GetByIdAsync(id);
            bool success = FileHelper.DeleteFile(bankAccount.Image, Path.Combine("Files", "homePageItems"));

            if (success)
            {
                return await _homePageItemDal.DeleteByIdAsync(id);
            }
            else
            {
                return false;
            }
        }

        public async Task<List<HomePageItem>> GetAllAsync()
        {
            return await _homePageItemDal.GetAllAsync();
        }

        public async Task<HomePageItem> GetByFilterAsync(Expression<Func<HomePageItem, bool>> predicate)
        {
            return await _homePageItemDal.GetByFilterAsync(predicate);
        }

        public async Task<HomePageItem> GetByIdAsync(int id)
        {
            return await _homePageItemDal.GetByIdAsync(id);
        }

        public Task<HomePageItem> GetWithIncludeById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<HomePageItem> UpdateAsync(HomePageItem homePageItem)
        {
            var existItem = await GetByIdAsync(homePageItem.Id);

            if (existItem != null && homePageItem.Image != null && existItem.Image != null)
            {
                FileHelper.DeleteFile(existItem.Image, Path.Combine("Files", "homePageItems"));
            }
            else if (existItem != null && homePageItem.Image == null)
            {
                homePageItem.Image = existItem.Image;
            }

            return await _homePageItemDal.UpdateAsync(homePageItem);
        }
    }
}
