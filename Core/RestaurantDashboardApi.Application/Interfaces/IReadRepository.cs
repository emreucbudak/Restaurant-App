using Microsoft.EntityFrameworkCore.Query;
using RestaurantDashboardApi.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDashboardApi.Application.Interfaces
{
    public interface IReadRepository <T> : IBaseEntity 
    {
        Task<IList<T>> GetAllAsync(
            Expression<Func<T, bool>>? predicate = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
            bool trackChanges = true,
            Func<IQueryable<T>, IOrderedQueryable<T>>? ordered = null
        );

        Task<IList<T>> GetAllAsyncWithPaging(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, Func<IQueryable<T>, IIncludableQueryable<T, object>>>? include = null, bool? trackChanges = null, Func<IQueryable<T>, IOrderedQueryable<T>>? ordered = null,int currentPage = 1,int pageSize = 5);
        IQueryable<T> GetByExpression (bool trackChanges , Expression<Func<T,bool>>?expression = null);

    }
}
