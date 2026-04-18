using Microsoft.EntityFrameworkCore;
using SubwayApp.Domain.Interfaces;
using SubwayApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SubwayApp.Infrastructure.Data
{
    public class GenericRepository : IGenericRepository where T : BaseEntity
    {
        private readonly AppDbContext _context;
        private readonly DbSet _dbSet;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = context.Set();
        }

        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

        public async Task DeleteAsync(T entity)
        {
            entity.IsDeleted = true;
            _dbSet.Update(entity);
        }

        public async Task> GetAllAsync() => await _dbSet.ToListAsync();

        public async Task GetByIdAsync(int id)
            => await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

        public async Task UpdateAsync(T entity) => _dbSet.Update(entity);

        public async Task> Where(Expression> expression)
            => await _dbSet.Where(expression).ToListAsync();
    }
}
