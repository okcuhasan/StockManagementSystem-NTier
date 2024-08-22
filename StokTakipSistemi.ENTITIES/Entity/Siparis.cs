using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.Entity
{
    public class Siparis : BaseEntity
    {
        public DateTime SiparisTarihi { get; set; }
        public int MusteriId { get; set; }
        public Musteri Musteri { get; set; }
        public int TedarikciId { get; set; }
        public Tedarikci Tedarikci { get; set; }
        public string SiparisDurumu { get; set; }
        public List<SiparisDetay> SiparisDetaylari { get; set; }
        public List<StokHareket> StokHareketleri { get; set; }
    }
}
