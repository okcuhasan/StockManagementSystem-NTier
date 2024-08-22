using Microsoft.EntityFrameworkCore;
using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.BLL.ManagerServices.Interfaces
{
    public interface IManager<T> where T : BaseEntity
    {
        IQueryable<T> GetAllQueryableBll();
        Task<List<T>> GetAllListAsyncBll();
        Task<T> GetByIdAsyncBll(int id);
        IQueryable<T> WhereQueryableBll(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultAsyncBll(Expression<Func<T, bool>> predicate);
        Task<T> SingleOrDefaultAsyncBll(Expression<Func<T, bool>> predicate);
        Task<T> FirstAsyncBll();
        Task<string> AddAsyncBll(T entity);
        Task<string> AddRangeAsyncBll(List<T> entities);
        Task<string> UpdateBll(T entity);
        Task<string> UpdateRangeBll(List<T> entities);
        Task<string> DeleteBll(T entity);
        Task<string> DeleteRangeBll(List<T> entities);
    }
}
