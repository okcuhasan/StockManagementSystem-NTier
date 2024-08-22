using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.Entity
{
    public class Kategori : BaseEntity
    {
        public string KategoriAdi { get; set; }
        public string? KategoriAciklamasi { get; set; }
        public List<Urun> Urunler { get; set; }
    }
}
