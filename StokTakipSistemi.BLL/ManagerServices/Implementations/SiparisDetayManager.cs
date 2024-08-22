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
    public class SiparisDetayManager : BaseManager<SiparisDetay>, ISiparisDetayManager
    {
        ISiparisDetayRepository _siparisDetayRepository;
        public SiparisDetayManager(ISiparisDetayRepository siparisDetayRepository) : base(siparisDetayRepository)
        {
            _siparisDetayRepository = siparisDetayRepository;
        }
    }
}
