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
    public class MusteriManager : BaseManager<Musteri>, IMusteriManager
    {
        IMusteriRepository _musteriRepository;
        public MusteriManager(IMusteriRepository musteriRepository) : base(musteriRepository)
        {
            _musteriRepository = musteriRepository;
        }
    }
}
