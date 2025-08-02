using Microsoft.EntityFrameworkCore;
using RestaurantDashboardApi.Application.Interfaces;
using RestaurantDashboardApi.Persistence.AppDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, new()

    {
        private readonly ApplicationDbContext _db;

        public WriteRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        private DbSet<T> _dbSet { get => _db.Set<T>(); }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IList<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public async Task DeleteAsync(T entity)
        {
            await Task.Run(() => _dbSet.Remove(entity));

        }

        public async Task DeleteRangeAsync(IList<T> entities)
        {
            await Task.Run(() => _dbSet.RemoveRange(entities));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => _dbSet.Update(entity));
        }
    }
}
