using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.EntityConfigurations
{
    public class MusteriConfiguration : BaseConfiguration<Musteri>
    {
        public override void Configure(EntityTypeBuilder<Musteri> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Siparisler).WithOne(x => x.Musteri).HasForeignKey(x => x.MusteriId);
        }
    }
}
