using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.BLL.ManagerServices.Interfaces
{
    public interface ISiparisManager : IManager<Siparis>
    {
        Task<List<Siparis>> GetAllSiparisWithRelationsBll();
        Task<Siparis> GetSiparisWithRelationsBll(int id);
    }
}
