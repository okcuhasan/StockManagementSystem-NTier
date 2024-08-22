using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.DataTransferObjects
{
    public class UrunDTO
    {
        public string UrunAdi { get; set; }
        public string? UrunAciklamasi { get; set; }
        public string? StokTutmaBirimiKodu { get; set; }
        public int KategoriId { get; set; }
        public decimal BirimFiyat { get; set; }
        public int MevcutStokMiktari { get; set; }
        public int YenidenSiparisSeviyesi { get; set; }
    }
}
