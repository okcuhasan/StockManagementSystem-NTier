using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.BLL.ManagerServices.Interfaces
{
    public interface IUrunManager : IManager<Urun>
    {
        Task<List<Urun>> GetAllUrunWithRelationsBll();
        Task<Urun> GetUrunWithRelationsBll(int id);
    }
}
