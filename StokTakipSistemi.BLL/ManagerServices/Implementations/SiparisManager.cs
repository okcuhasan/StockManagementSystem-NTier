using Microsoft.EntityFrameworkCore;
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
    public class SiparisManager : BaseManager<Siparis>, ISiparisManager
    {
        ISiparisRepository _siparisRepository;
        public SiparisManager(ISiparisRepository siparisRepository) : base(siparisRepository)
        {
            _siparisRepository = siparisRepository;
        }

        public async Task<List<Siparis>> GetAllSiparisWithRelationsBll()
        {
            return await _siparisRepository.GetAllSiparisWithRelations();
        }

        public async Task<Siparis> GetSiparisWithRelationsBll(int id)
        {
            return await _siparisRepository.GetSiparisWithRelations(id);
        }
    }
}
