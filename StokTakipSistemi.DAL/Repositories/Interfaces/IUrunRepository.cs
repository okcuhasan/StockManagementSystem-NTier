using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.Repositories.Interfaces
{
    public interface IUrunRepository : IGenericRepository<Urun>
    {
        Task<List<Urun>> GetAllUrunWithRelations();
        Task<Urun> GetUrunWithRelations(int id);
    }
}
