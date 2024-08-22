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
    public class UrunRepository : GenericRepository<Urun>, IUrunRepository
    {
        ApplicationDbContext _context;
        public UrunRepository(ApplicationDbContext context) : base(context)
        {
            _context = context; 
        }

        public async Task<List<Urun>> GetAllUrunWithRelations()
        {
            return await _context.Urunler.Include(x => x.Kategori).ToListAsync();
        }

        public async Task<Urun> GetUrunWithRelations(int id)
        {
            return await _context.Urunler.Include(x => x.Kategori).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
