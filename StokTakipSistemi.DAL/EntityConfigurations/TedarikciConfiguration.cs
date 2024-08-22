using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.DAL.EntityConfigurations
{
    public class TedarikciConfiguration : BaseConfiguration<Tedarikci>
    {
        public override void Configure(EntityTypeBuilder<Tedarikci> builder)
        {
            base.Configure(builder);

            builder.HasMany(x => x.Siparisler).WithOne(x => x.Tedarikci).HasForeignKey(x => x.TedarikciId);
        }
    }
}
