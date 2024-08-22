using StokTakipSistemi.ENTITIES.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.Entity
{
    public class Tedarikci : BaseEntity
    {
        public string TedarikciAdi { get; set; }
        public string? MailAdresi { get; set; }
        public string? TelefonNumarasi { get; set; }
        public string? Adres { get; set; }
        public List<Siparis> Siparisler { get; set; }
    }
}
