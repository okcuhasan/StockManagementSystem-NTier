using Microsoft.EntityFrameworkCore;
using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        DbSet<T> Entity { get; }
        IQueryable<T> GetAllQueryable();
        Task<List<T>> GetAllListAsync();
        Task<T> GetByIdAsync(int id);
        IQueryable<T> WhereQueryable(Expression<Func<T, bool>> predicate); 
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstAsync();
        Task<bool> AddAsync(T entity);
        Task AddRangeAsync(List<T> entities);
        Task<bool> Update(T entity);
        Task UpdateRange(List<T> entities);
        Task<bool> Delete(T entity);
        Task DeleteRange(List<T> entities);
    }
}
