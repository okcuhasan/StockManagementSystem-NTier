using Microsoft.EntityFrameworkCore;
using StokTakipSistemi.DAL.EntityConfigurations;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new KategoriConfiguration());
            builder.ApplyConfiguration(new MusteriConfiguration());
            builder.ApplyConfiguration(new SiparisConfiguration());
            builder.ApplyConfiguration(new SiparisDetayConfiguration());
            builder.ApplyConfiguration(new TedarikciConfiguration());
            builder.ApplyConfiguration(new UrunConfiguration());
            builder.ApplyConfiguration(new StokHareketConfiguration());
        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<SiparisDetay> SiparisDetaylari { get; set; }
        public DbSet<Tedarikci> Tedarikciler { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<StokHareket> StokHareketleri { get; set; }
    }
}
