using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.Entity
{
    public class StokHareket : BaseEntity
    {
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public string HareketTuru { get; set; }
        public int Miktar { get; set; }
        public DateTime HareketTarihi { get; set; }
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
    }
}
