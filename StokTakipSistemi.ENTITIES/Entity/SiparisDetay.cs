using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.Entity
{
    public class SiparisDetay : BaseEntity
    {
        public int SiparisId { get; set; }
        public Siparis Siparis { get; set; }
        public int UrunId { get; set; }
        public Urun Urun { get; set; }
        public int SiparisMiktari { get; set; }
        public decimal UrunBirimFiyati { get; set; }
    }
}
