using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Interfaces.UnitOfWorks
{
    public interface IUnitOfWork : IAsyncDisposable 
    {
        IReadRepository<T> GetReadRepository<T>() where T : class, IBaseEntity, new();
        IWriteRepository<T> GetWriteRepository<T>() where T : class, IBaseEntity, new();
        Task<int> SaveAsync();
        int Save();
    }
}
