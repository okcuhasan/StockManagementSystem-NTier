using StokTakipSistemi.BLL.ManagerServices.Interfaces;
using StokTakipSistemi.DAL.Repositories.Interfaces;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.BLL.ManagerServices.Implementations
{
    public class UrunManager : BaseManager<Urun>, IUrunManager
    {
        IUrunRepository _urunRepository;
        public UrunManager(IUrunRepository urunRepository) : base(urunRepository)
        {
            _urunRepository = urunRepository;
        }

        public async Task<List<Urun>> GetAllUrunWithRelationsBll()
        {
            return await _urunRepository.GetAllUrunWithRelations();
        }
        public async Task<Urun> GetUrunWithRelationsBll(int id)
        {
            return await _urunRepository.GetUrunWithRelations(id);
        }
    }
}
