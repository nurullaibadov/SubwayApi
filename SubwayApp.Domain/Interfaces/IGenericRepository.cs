using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SubwayApp.Domain.Entities;

namespace SubwayApp.Domain.Interfaces
{
    public interface IGenericRepository where T : BaseEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task GetByIdAsync(int id);
        Task> GetAllAsync();
        Task> Where(Expression> expression);
    }
}
