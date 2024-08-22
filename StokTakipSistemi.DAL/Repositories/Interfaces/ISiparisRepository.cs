using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.Repositories.Interfaces
{
    public interface ISiparisRepository : IGenericRepository<Siparis>
    {
        Task<List<Siparis>> GetAllSiparisWithRelations();
        Task<Siparis> GetSiparisWithRelations(int id);
    }
}
