using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Collections;
using CoreLayer.Persistence.Paging;
using CoreLayer.Persistence.Dynamic;
using CoreLayer.BaseEntities;

namespace CoreLayer.EntityFramework;

public class EfEntityRepositoryBase<TEntity, TEntityId, TContext> : IEntityRepository<TEntity,TEntityId>
    where TEntity : BaseEntity<TEntityId>
    where TContext : DbContext
{
    protected readonly TContext _context;

    public EfEntityRepositoryBase(TContext context)
    {
        _context = context;
    }

    protected virtual void EditEntityPropertiesToAdd(TEntity entity)
    {
        entity.CreatedDate = DateTime.UtcNow;
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        EditEntityPropertiesToAdd(entity);
        _context.Add(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<TEntity>> AddListAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            EditEntityPropertiesToAdd(entity);
        }
        await _context.AddRangeAsync(entities);
        await _context.SaveChangesAsync();

        return entities;
    }

    public async Task DeleteAsync(TEntity t, CancellationToken cancellationToken = default)
    {
        _context.Entry(t).State = EntityState.Detached;
        _context.Remove(t);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> DeleteByIdAsync(TEntityId id, CancellationToken cancellationToken = default)
    {
        var data = await _context.Set<TEntity>().FindAsync(id);

        if (data == null)
            return false;

        _context.Remove(data);

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null, Func<IQueryable<TEntity>,
                                                 IIncludableQueryable<TEntity, object>>? include = null, CancellationToken cancellationToken = default)
    {
        var queryable = Query();

        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);

        return await queryable.AsNoTracking().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TEntityId id, bool enableTracking = false, CancellationToken cancellationToken = default)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);

        if (entity != null && !enableTracking)
        {
            _context.Entry(entity).State = EntityState.Detached;
        }

        return entity;
    }

    protected virtual void EditEntityPropertiesToUpdate(TEntity entity)
    {
        entity.UpdatedDate = DateTime.UtcNow;
    }

    public async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        EditEntityPropertiesToAdd(entity);
        
        _context.Update(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task<List<TEntity>> UpdateListAsync(List<TEntity> entities, CancellationToken cancellationToken = default)
    {
        foreach (var entity in entities)
        {
            EditEntityPropertiesToAdd(entity);
        }

        _context.UpdateRange(entities);
        await _context.SaveChangesAsync();

        return entities;
    }

    public async Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate,
                                                        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                       include = null, bool enableTracking = false,
                                                        CancellationToken cancellationToken = default)
    {
        var queryable = Query();

        if (include != null) queryable = include(queryable);

        if (!enableTracking) queryable = queryable.AsNoTracking();

        return await queryable.FirstOrDefaultAsync(predicate);
    }

    public async Task<int> GetCountAsync(Expression<Func<TEntity, bool>> predicate = null, CancellationToken cancellationToken = default)
    {
        var queryable = Query();

        if (predicate != null) queryable = queryable.Where(predicate);

        return await queryable.AsNoTracking().CountAsync();
    }

    public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                   Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                       null,
                                                   Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                       include = null,
                                                   int draw = 0, int length = 10, bool enableTracking = false,
                                                   CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(draw, length, 0, cancellationToken);
        return await queryable.ToPaginateAsync(draw, length, 0, cancellationToken);
    }
    public async Task<IPaginate<TEntity>> GetListByDataTableQueryAsync(string queryString,
                                                        Func<IQueryable<TEntity>,
                                                                IIncludableQueryable<TEntity, object>>?
                                                            include = null,
                                                        bool enableTracking = false,
                                                        Expression<Func<TEntity, bool>> predicate = null,
                                                        CancellationToken cancellationToken = default)
    {
        GetListQuery getListQuery = QueryStringParser.Parse(queryString, typeof(TEntity));

        return await GetListByDynamicAsync(getListQuery.Dynamic, include, getListQuery.PageRequest.Page, getListQuery.PageRequest.PageSize, enableTracking, predicate, cancellationToken);
    }
    public async Task<IPaginate<TEntity>> GetListByDataTableQueryAndDynamicAsync(string queryString,
                                                        Func<IQueryable<TEntity>,
                                                                IIncludableQueryable<TEntity, object>>?
                                                            include = null,
                                                        bool enableTracking = false,
                                                        Expression<Func<TEntity, bool>> predicate = null,
                                                        CancellationToken cancellationToken = default)
    {
        GetListQuery getListQuery = QueryStringParser.Parse(queryString, typeof(TEntity));

        return await GetListByDynamicAsync(getListQuery.Dynamic, include, getListQuery.PageRequest.Page, getListQuery.PageRequest.PageSize, enableTracking, predicate, cancellationToken);
    }

    public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic dynamic,
                                                            Func<IQueryable<TEntity>,
                                                                    IIncludableQueryable<TEntity, object>>?
                                                                include = null,
                                                            int index = 0, int size = 10,
                                                            bool enableTracking = false,
                                                            Expression<Func<TEntity, bool>> predicate = null,
                                                            CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);

        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public async Task<IEnumerable<TResult>> GetChartDataAsync<TResult>(
        string dateSelector,
        TimeSpan interval,
        Expression<Func<IGrouping<DateTime, TEntity>, TResult>> selector,
        DateTime? startDate = null,
        DateTime? endDate = null,
        Expression<Func<TEntity, bool>>? predicate = null,
        bool includeZeros = false, CancellationToken cancellationToken = default)
    {
        var query = Query();

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        var parameter = Expression.Parameter(typeof(TEntity), "e");
        var property = Expression.Property(parameter, dateSelector);
        var isNullable = property.Type == typeof(DateTime?);

        Expression<Func<TEntity, DateTime>> dateSelectorLambda;

        if (isNullable)
        {
            var nullCheck = Expression.NotEqual(property, Expression.Constant(null, typeof(DateTime?)));
            var nonNullableProperty = Expression.Convert(property, typeof(DateTime));
            dateSelectorLambda = Expression.Lambda<Func<TEntity, DateTime>>(nonNullableProperty, parameter);
            query = query.Where(Expression.Lambda<Func<TEntity, bool>>(nullCheck, parameter));
        }
        else
        {
            dateSelectorLambda = Expression.Lambda<Func<TEntity, DateTime>>(property, parameter);
        }

        if (startDate.HasValue)
        {
            var startDateExpression = Expression.GreaterThanOrEqual(dateSelectorLambda.Body, Expression.Constant(startDate.Value, typeof(DateTime)));
            query = query.Where(Expression.Lambda<Func<TEntity, bool>>(startDateExpression, parameter));
        }

        if (endDate.HasValue)
        {
            var endDateExpression = Expression.LessThanOrEqual(dateSelectorLambda.Body, Expression.Constant(endDate.Value, typeof(DateTime)));
            query = query.Where(Expression.Lambda<Func<TEntity, bool>>(endDateExpression, parameter));
        }

        var data = await query.AsNoTracking().ToListAsync();

        var groupedData = data
            .AsEnumerable()
            .GroupBy(e => new DateTime(
                dateSelectorLambda.Compile()(e).Ticks / interval.Ticks * interval.Ticks))
            .Select(g => new
            {
                Date = g.Key,
                Count = g.Count()
            })
            .ToList();

        var result = new List<TResult>();
        var compiledSelector = selector.Compile();

        DateTime minDate = startDate ?? groupedData.Min(g => g.Date);
        DateTime maxDate = endDate ?? groupedData.Max(g => g.Date);

        for (var date = minDate.Date; date <= maxDate.Date; date = date.AddDays(1))
        {
            var key = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
            var count = groupedData.FirstOrDefault(d => d.Date == key)?.Count ?? 0;

            if (includeZeros || count > 0)
            {
                var fakeGroup = new
                {
                    Key = key,
                    Elements = Enumerable.Repeat(default(TEntity), count)
                };
                var selectedResult = compiledSelector(new GroupingFake<DateTime, TEntity>(fakeGroup.Key, fakeGroup.Elements));
                result.Add(selectedResult);
            }
        }

        return result;
    }

    public IQueryable<TEntity> Query()
    {
        return _context.Set<TEntity>();
    }
}

class GroupingFake<TKey, TElement> : IGrouping<TKey, TElement>
{
    public TKey Key { get; }
    private readonly IEnumerable<TElement> _elements;

    public GroupingFake(TKey key, IEnumerable<TElement> elements)
    {
        Key = key;
        _elements = elements;
    }

    public IEnumerator<TElement> GetEnumerator() => _elements.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

