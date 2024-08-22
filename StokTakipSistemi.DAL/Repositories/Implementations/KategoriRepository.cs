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
    public class KategoriRepository : GenericRepository<Kategori>, IKategoriRepository
    {
        ApplicationDbContext _context;
        public KategoriRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }


    }
}
