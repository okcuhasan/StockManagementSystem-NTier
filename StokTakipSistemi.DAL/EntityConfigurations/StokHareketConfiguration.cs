using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.EntityConfigurations
{
    public class StokHareketConfiguration : BaseConfiguration<StokHareket>
    {
        public override void Configure(EntityTypeBuilder<StokHareket> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Urun).WithMany(x => x.StokHareketleri).HasForeignKey(x => x.UrunId);
            builder.HasOne(x => x.Siparis).WithMany(x => x.StokHareketleri).HasForeignKey(x => x.SiparisId);
        }
    }
}
