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
    public class TedarikciManager : BaseManager<Tedarikci>, ITedarikciManager
    {
        ITedarikciRepository _tedarikciRepository;
        public TedarikciManager(ITedarikciRepository tedarikciRepository) : base(tedarikciRepository)
        {
            _tedarikciRepository = tedarikciRepository; 
        }

    }
}
