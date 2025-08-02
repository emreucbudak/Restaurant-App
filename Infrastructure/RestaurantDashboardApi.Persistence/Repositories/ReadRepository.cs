using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantDashboardApi.Application.Interfaces;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using RestaurantDashboardApi.Persistence.AppDbContext;
using Microsoft.EntityFrameworkCore;
namespace RestaurantDashboardApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IBaseEntity, new()
    {
        private readonly ApplicationDbContext _context;

        public ReadRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        private DbSet<T> _dbSet { get => _context.Set<T>(); }
        public async Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool trackChanges = true,
            Func<IQueryable<T>, IOrderedQueryable<T>>? ordered = null)
        {
            IQueryable<T> query = _dbSet;

            if (!trackChanges)
                query = query.AsNoTracking();

            if (include != null)
                query = include(query);

            if (predicate != null)
                query = query.Where(predicate);

            if (ordered != null)
                query = ordered(query);

            return await query.ToListAsync();
        }


        public async Task<IList<T>> GetAllAsyncWithPaging(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, Func<IQueryable<T>, IIncludableQueryable<T, object>>>? include = null, bool? trackChanges = null, Func<IQueryable<T>, IOrderedQueryable<T>>? ordered = null, int currentPage = 1, int pageSize = 5)
        {
            IQueryable<T> query = _dbSet;
            if (trackChanges is not null) query.AsNoTracking();
            if (include is not null) include(query);
            if (predicate is not null) query = query.Where(predicate);
            if (ordered is not null) ordered(query).Skip((currentPage - 1 ) * pageSize).Take(pageSize);
            return await query.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public IQueryable<T> GetByExpression(bool trackChanges, Expression<Func<T, bool>>? expression = null)
        {
            if (!trackChanges) _dbSet.AsNoTracking();
            return _dbSet.Where(expression);
        }
    }
}
