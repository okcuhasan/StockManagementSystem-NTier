using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using StokTakipSistemi.DAL.Context;
using StokTakipSistemi.DAL.Repositories.Interfaces;
using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        ApplicationDbContext _context;
        public GenericRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public DbSet<T> Entity => _context.Set<T>();
        public IQueryable<T> GetAllQueryable()
        {
            IQueryable<T> queryable = Entity.AsQueryable();
            return queryable;
        }
        public async Task<List<T>> GetAllListAsync()
        {
            List<T> entities = await Entity.ToListAsync();
            return entities;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            T entity = await Entity.FindAsync(id);
            return entity;
        }
        public IQueryable<T> WhereQueryable(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> entities = Entity.Where(predicate);
            return entities;
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            T entity = await Entity.FirstOrDefaultAsync(predicate);
            return entity;
        }
        public async Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            T entity = await Entity.SingleOrDefaultAsync(predicate);
            return entity;
        }
        public async Task<T> FirstAsync()
        {
            T entity = await Entity.FirstOrDefaultAsync();
            return entity;
        }
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry entityEntry = await Entity.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entityEntry.State == EntityState.Added;
        }
        public async Task AddRangeAsync(List<T> entities)
        {
            await Entity.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Update(T entity)
        {
            EntityEntry entityEntry = Entity.Update(entity);
            await _context.SaveChangesAsync();
            return entityEntry.State == EntityState.Modified;
        }
        public async Task UpdateRange(List<T> entities)
        {
            Entity.UpdateRange(entities);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> Delete(T entity)
        {
            EntityEntry entityEntry = Entity.Remove(entity);
            await _context.SaveChangesAsync();
            return entityEntry.State == EntityState.Deleted;
        }
        public async Task DeleteRange(List<T> entities)
        {
            Entity.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
