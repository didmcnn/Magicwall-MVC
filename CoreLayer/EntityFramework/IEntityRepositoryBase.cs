using CoreLayer.BaseEntities;
using CoreLayer.Persistence.Dynamic;
using CoreLayer.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CoreLayer.EntityFramework;

public interface IEntityRepository<TEntity, TEntityId> where TEntity : BaseEntity<TEntityId>
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<List<TEntity>> AddListAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
    Task DeleteAsync(TEntity t, CancellationToken cancellationToken = default);
    Task<bool> DeleteByIdAsync(TEntityId id, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>,
                                    IIncludableQueryable<TEntity, object>>? include = null,
                                    CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(TEntityId id, bool enableTracking = false, CancellationToken cancellationToken = default);
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<List<TEntity>> UpdateListAsync(List<TEntity> entities, CancellationToken cancellationToken = default);
    Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate,
                                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                       include = null, bool enableTracking = false,
                                                        CancellationToken cancellationToken = default);
    Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default);
    Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                       null,
                                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                       include = null,
                                                   int draw = 0, int length = 10, bool enableTracking = false,
                                                   CancellationToken cancellationToken = default);
    Task<IPaginate<TEntity>> GetListByDataTableQueryAndDynamicAsync(string queryString,
                                                        Func<IQueryable<TEntity>,
                                                                IIncludableQueryable<TEntity, object>>?
                                                            include = null,
                                                        bool enableTracking = false,
                                                        Expression<Func<TEntity, bool>> predicate = null,
                                                        CancellationToken cancellationToken = default);
    Task<IPaginate<TEntity>> GetListByDataTableQueryAsync(string queryString,
                                                            Func<IQueryable<TEntity>,
                                                                    IIncludableQueryable<TEntity, object>>?
                                                                include = null,
                                                            bool enableTracking = false,
                                                            Expression<Func<TEntity, bool>>? predicate = null,
                                                            CancellationToken cancellationToken = default);

    Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic dynamic,
                                                            Func<IQueryable<TEntity>,
                                                                    IIncludableQueryable<TEntity, object>>?
                                                                include = null,
                                                            int index = 0, int size = 10,
                                                            bool enableTracking = false,
                                                            Expression<Func<TEntity, bool>> predicate = null,
                                                            CancellationToken cancellationToken = default);

    Task<IEnumerable<TResult>> GetChartDataAsync<TResult>(
        string dateSelector,
        TimeSpan interval,
        Expression<Func<IGrouping<DateTime, TEntity>, TResult>> selector,
        DateTime? startDate = null,
        DateTime? endDate = null,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool includeZeros = false, CancellationToken cancellationToken = default);

    IQueryable<TEntity> Query();
}
