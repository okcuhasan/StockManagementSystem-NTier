using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.EntityConfigurations
{
    public class SiparisDetayConfiguration : BaseConfiguration<SiparisDetay>
    {
        public override void Configure(EntityTypeBuilder<SiparisDetay> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Siparis).WithMany(x => x.SiparisDetaylari).HasForeignKey(x => x.SiparisId);
            builder.HasOne(x => x.Urun).WithMany(x => x.SiparisDetaylari).HasForeignKey(x => x.UrunId);
        }
    }
}
