using StokTakipSistemi.DAL.Context;
using StokTakipSistemi.DAL.Repositories.Interfaces;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.Repositories.Implementations
{
    public class TedarikciRepository : GenericRepository<Tedarikci>, ITedarikciRepository
    {
        ApplicationDbContext _context;
        public TedarikciRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
