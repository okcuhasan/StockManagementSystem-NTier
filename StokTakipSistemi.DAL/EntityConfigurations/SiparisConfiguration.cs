using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.EntityConfigurations
{
    public class SiparisConfiguration : BaseConfiguration<Siparis>
    {
        public override void Configure(EntityTypeBuilder<Siparis> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Musteri).WithMany(x => x.Siparisler).HasForeignKey(x => x.MusteriId);
            builder.HasOne(x => x.Tedarikci).WithMany(x => x.Siparisler).HasForeignKey(x => x.TedarikciId);
            builder.HasMany(x => x.StokHareketleri).WithOne(x => x.Siparis).HasForeignKey(x => x.SiparisId);
        }
    }
}
