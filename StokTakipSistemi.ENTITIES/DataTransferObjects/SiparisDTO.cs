using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.DataTransferObjects
{
    public class SiparisDTO
    {
        public DateTime SiparisTarihi { get; set; }
        public int MusteriId { get; set; }
        public int TedarikciId { get; set; }
        public string SiparisDurumu { get; set; }
        public List<SiparisDetayDTO> SiparisDetaylari { get; set; }
    }
}
