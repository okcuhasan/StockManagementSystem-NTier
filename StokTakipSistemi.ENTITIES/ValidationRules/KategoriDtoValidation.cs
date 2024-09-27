using FluentValidation;
using StokTakipSistemi.ENTITIES.DataTransferObjects;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.ValidationRules
{
    public class KategoriDtoValidation : AbstractValidator<KategoriDTO>
    {
        public KategoriDtoValidation()
        {
            RuleFor(x => x.KategoriAdi).NotEmpty().WithMessage("Kategori Adı boş geçilemez!");
        }
    }
}
