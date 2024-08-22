using Microsoft.EntityFrameworkCore;
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
    public class SiparisRepository : GenericRepository<Siparis>, ISiparisRepository
    {
        ApplicationDbContext _context;
        public SiparisRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Siparis>> GetAllSiparisWithRelations()
        {
            List<Siparis> siparisler = await _context.Siparisler
                .Include(x => x.Musteri)
                .Include(x => x.Tedarikci)
                .ToListAsync();

            return siparisler;
        }

        public async Task<Siparis> GetSiparisWithRelations(int id)
        {
            Siparis siparis = await _context.Siparisler
                .Include(x => x.Musteri)
                .Include(x => x.Tedarikci)
                .FirstOrDefaultAsync(x => x.Id == id);

            return siparis;
        }
    }
}
