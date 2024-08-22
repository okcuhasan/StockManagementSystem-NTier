using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.EntityConfigurations
{
    public class UrunConfiguration : BaseConfiguration<Urun>
    {
        public override void Configure(EntityTypeBuilder<Urun> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Kategori).WithMany(x => x.Urunler).HasForeignKey(x => x.KategoriId);
            builder.HasMany(x => x.SiparisDetaylari).WithOne(x => x.Urun).HasForeignKey(x => x.UrunId);
            builder.HasMany(x => x.StokHareketleri).WithOne(x => x.Urun).HasForeignKey(x => x.UrunId);
        }
    }
}
