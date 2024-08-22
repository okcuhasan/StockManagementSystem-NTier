using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokTakipSistemi.BLL.ManagerServices.Implementations;
using StokTakipSistemi.BLL.ManagerServices.Interfaces;
using StokTakipSistemi.ENTITIES.DataTransferObjects;
using StokTakipSistemi.ENTITIES.Entity;

namespace StokTakipSistemi.RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiparisController : ControllerBase
    {
        ISiparisManager _siparisManager;
        IMapper _mapper;
        public SiparisController(ISiparisManager siparisManager, IMapper mapper)
        {
            _siparisManager = siparisManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SiparisleriListele()
        {
            List<Siparis> siparisler = await _siparisManager.GetAllSiparisWithRelationsBll();
            var iliskiliSiparisler = siparisler.Select(x => new
            {
                SiparişId = x.Id,
                SiparişTarihi = x.SiparisTarihi,
                MüşteriAdı = x.Musteri.MusteriAdi,
                MüşteriMailAdresi = x.Musteri.MailAdresi,
                MüşteriTelefonNumarası = x.Musteri.TelefonNumarasi,
                MüşteriAdresi = x.Musteri.Adres,
                TedarikçiAdı = x.Tedarikci.TedarikciAdi,
                TedarikçiMailAdresi = x.Tedarikci.MailAdresi,
                TedarikçiTelefonNumarası = x.Tedarikci.TelefonNumarasi,
                TedarikçiAdresi = x.Tedarikci.Adres,
                SiparişDurumu = x.SiparisDurumu
            }).ToList();

            return Ok(iliskiliSiparisler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> SiparisGetir(int id)
        {
            if(id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Siparis siparis = await _siparisManager.GetSiparisWithRelationsBll(id);
                if(siparis == null)
                {
                    return NotFound("Sipariş bulunamadı!");
                }
                else
                {
                    var iliskiliSiparis = new
                    {
                        SiparişId = siparis.Id,
                        SiparişTarihi = siparis.SiparisTarihi,
                        MüşteriAdı = siparis.Musteri.MusteriAdi,
                        MüşteriMailAdresi = siparis.Musteri.MailAdresi,
                        MüşteriTelefonNumarası = siparis.Musteri.TelefonNumarasi,
                        MüşteriAdresi = siparis.Musteri.Adres,
                        TedarikçiAdı = siparis.Tedarikci.TedarikciAdi,
                        TedarikçiMailAdresi = siparis.Tedarikci.MailAdresi,
                        TedarikçiTelefonNumarası = siparis.Tedarikci.TelefonNumarasi,
                        TedarikçiAdresi = siparis.Tedarikci.Adres,
                        SiparişDurumu = siparis.SiparisDurumu
                    };

                    return Ok(iliskiliSiparis);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> SiparisEkle(SiparisDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                Siparis siparis = _mapper.Map<Siparis>(dTO);
                string mesaj = await _siparisManager.AddAsyncBll(siparis);

                return Ok(mesaj);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> SiparisGuncelle(int id, SiparisDTO dTO)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                Siparis siparis = await _siparisManager.GetByIdAsyncBll(id);
                if (siparis == null)
                {
                    return NotFound("Sipariş bulunamadı");
                }
                else
                {
                    _mapper.Map(dTO, siparis);
                    string mesaj = await _siparisManager.UpdateBll(siparis);

                    return Ok(mesaj);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SiparisSil(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Siparis siparis = await _siparisManager.GetByIdAsyncBll(id);
                if (siparis == null)
                {
                    return NotFound("Sipariş bulunamadı");
                }
                else
                {
                    string mesaj = await _siparisManager.DeleteBll(siparis);
                    return Ok(mesaj);
                }
            }
        }

        [HttpGet("SiparisAra")]
        public async Task<IActionResult> SiparisAra(string siparisBilgisi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                IQueryable<Siparis> siparis = _siparisManager.WhereQueryableBll(x => x.Musteri.MusteriAdi == siparisBilgisi || x.Tedarikci.TedarikciAdi == siparisBilgisi);
                if (!siparis.Any()) // Any metodu sorgu çalıştırılmadan önce ilgili veri kümesi var mı yok mu bunu kontrol eder bu nedenle iqueryable ile kullanılır, filtreye uyan veri veya veriler var mı anlamında.
                {
                    return NotFound("Sipariş bulunamadı");
                }
                else
                {
                    List<Siparis> siparisler = await siparis.Include(x => x.Musteri).Include(x => x.Tedarikci).ToListAsync();
                    var iliskiliSiparisler = siparisler.Select(x => new
                    {
                        SiparişId = x.Id,
                        SiparişTarihi = x.SiparisTarihi,
                        MüşteriAdı = x.Musteri.MusteriAdi,
                        MüşteriMailAdresi = x.Musteri.MailAdresi,
                        MüşteriTelefonNumarası = x.Musteri.TelefonNumarasi,
                        MüşteriAdresi = x.Musteri.Adres,
                        TedarikçiAdı = x.Tedarikci.TedarikciAdi,
                        TedarikçiMailAdresi = x.Tedarikci.MailAdresi,
                        TedarikçiTelefonNumarası = x.Tedarikci.TelefonNumarasi,
                        TedarikçiAdresi = x.Tedarikci.Adres,
                        SiparişDurumu = x.SiparisDurumu
                    }).ToList();

                    return Ok(iliskiliSiparisler);
                }
            }
        }
    }
}
