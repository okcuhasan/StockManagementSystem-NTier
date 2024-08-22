using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.EntityConfigurations
{
    public class KategoriConfiguration : BaseConfiguration<Kategori>
    {
        public override void Configure(EntityTypeBuilder<Kategori> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Urunler).WithOne(x => x.Kategori).HasForeignKey(x => x.KategoriId);
        }
    }
}
