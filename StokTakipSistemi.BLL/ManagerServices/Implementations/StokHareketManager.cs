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
    public class StokHareketManager : BaseManager<StokHareket>, IStokHareketManager
    {
        IStokHareketRepository _stokHareketRepository;
        public StokHareketManager(IStokHareketRepository stokHareketRepository) : base(stokHareketRepository)
        {
            _stokHareketRepository = stokHareketRepository;
        }
    }
}
