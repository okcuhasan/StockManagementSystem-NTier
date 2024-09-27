using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.DataTransferObjects
{
    public class SiparisDetayDTO
    {
        public int UrunId { get; set; }
        public int SiparisMiktari { get; set; }
        public decimal UrunBirimFiyati { get; set; }
    }
}
