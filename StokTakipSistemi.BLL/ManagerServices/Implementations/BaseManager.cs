using StokTakipSistemi.BLL.ManagerServices.Interfaces;
using StokTakipSistemi.DAL.Repositories.Interfaces;
using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.BLL.ManagerServices.Implementations
{
    public class BaseManager<T> : IManager<T> where T : BaseEntity
    {
        IGenericRepository<T> _repository;
        public BaseManager(IGenericRepository<T> repository) 
        {
            _repository = repository;
        }

        public IQueryable<T> GetAllQueryableBll()
        {
            return _repository.GetAllQueryable();
        }
        public async Task<List<T>> GetAllListAsyncBll()
        {
            return await _repository.GetAllListAsync();
        }
        public async Task<T> GetByIdAsyncBll(int id)
        {
            return await _repository.GetByIdAsync(id);
        }
        public IQueryable<T> WhereQueryableBll(Expression<Func<T, bool>> predicate)
        {
            return _repository.WhereQueryable(predicate);
        }
        public async Task<T> FirstOrDefaultAsyncBll(Expression<Func<T, bool>> predicate)
        {
            return await _repository.FirstOrDefaultAsync(predicate);
        }
        public async Task<T> SingleOrDefaultAsyncBll(Expression<Func<T, bool>> predicate)
        {
            return await _repository.SingleOrDefaultAsync(predicate);
        }
        public async Task<T> FirstAsyncBll()
        {
            return await _repository.FirstAsync();
        }
        public async Task<string> AddAsyncBll(T item)
        {
            await _repository.AddAsync(item);
            return "Ekleme işlemi başarılı";
        }
        public async Task<string> AddRangeAsyncBll(List<T> items)
        {
            await _repository.AddRangeAsync(items);
            return "Ekleme işlemleri başarılı";
        }
        public async Task<string> UpdateBll(T item)
        {
            await _repository.Update(item);
            return "Güncelleme işlemi başarılı";
        }
        public async Task<string> UpdateRangeBll(List<T> items)
        {
            await _repository.UpdateRange(items);
            return "Güncelleme işlemleri başarılı";
        }
        public async Task<string> DeleteBll(T item)
        {
            await _repository.Delete(item);
            return "Silme işlemi başarılı";
        }
        public async Task<string> DeleteRangeBll(List<T> items)
        {
            await _repository.DeleteRange(items);
            return "Silme işlemleri başarılı";
        }
    }
}
