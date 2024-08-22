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
    public class UrunController : ControllerBase
    {
        IUrunManager _urunManager;
        IMapper _mapper;
        public UrunController(IUrunManager urunManager, IMapper mapper)
        {
            _urunManager = urunManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> UrunleriListele()
        {
            List<Urun> urunler = await _urunManager.GetAllUrunWithRelationsBll();
            var iliskiliUrunler = urunler.Select(x => new
            {
                ÜrünId = x.Id,
                ÜrünAçıklaması = x.UrunAciklamasi,
                StokTutmaBirimiKodu = x.StokTutmaBirimiKodu,
                KategoriId = x.Kategori.Id,
                KategoriAdı = x.Kategori.KategoriAdi,
                BirimFiyat = x.BirimFiyat,
                MevcutStokMiktarı = x.MevcutStokMiktari,
                YenidenSiparişSeviyesi = x.YenidenSiparisSeviyesi
            }).ToList();

            return Ok(iliskiliUrunler);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> UrunGetir(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Urun urun = await _urunManager.GetUrunWithRelationsBll(id);
                if (urun == null)
                {
                    return NotFound("Ürün bulunamadı!");
                }
                else
                {
                    var iliskiliUrun = new
                    {
                        ÜrünId = urun.Id,
                        ÜrünAçıklaması = urun.UrunAciklamasi,
                        StokTutmaBirimiKodu = urun.StokTutmaBirimiKodu,
                        KategoriId = urun.Kategori.Id,
                        KategoriAdı = urun.Kategori.KategoriAdi,
                        BirimFiyat = urun.BirimFiyat,
                        MevcutStokMiktarı = urun.MevcutStokMiktari,
                        YenidenSiparişSeviyesi = urun.YenidenSiparisSeviyesi
                    };

                    return Ok(iliskiliUrun);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> UrunEkle(UrunDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                Urun urun = _mapper.Map<Urun>(dTO);
                string mesaj = await _urunManager.AddAsyncBll(urun);

                return Ok(mesaj);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UrunGuncelle(int id, UrunDTO dTO)
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
                Urun urun = await _urunManager.GetByIdAsyncBll(id);
                if (urun == null)
                {
                    return NotFound("Ürün bulunamadı");
                }
                else
                {
                    _mapper.Map(dTO, urun);
                    string mesaj = await _urunManager.UpdateBll(urun);

                    return Ok(mesaj);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> UrunSil(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Urun urun = await _urunManager.GetByIdAsyncBll(id);
                if (urun == null)
                {
                    return NotFound("Ürün bulunamadı");
                }
                else
                {
                    string mesaj = await _urunManager.DeleteBll(urun);
                    return Ok(mesaj);
                }
            }
        }

        [HttpGet("UrunAra")]
        public async Task<IActionResult> UrunAra(string urunBilgisi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                IQueryable<Urun> urun = _urunManager.WhereQueryableBll(x => x.UrunAdi == urunBilgisi || x.UrunAciklamasi == urunBilgisi);
                if (!urun.Any())
                {
                    return NotFound("Ürün bulunamadı");
                }
                else
                {
                    List<Urun> urunler = await urun.Include(x => x.Kategori).ToListAsync();
                    var iliskiliUrunler = urunler.Select(x => new
                    {
                        ÜrünId = x.Id,
                        ÜrünAçıklaması = x.UrunAciklamasi,
                        StokTutmaBirimiKodu = x.StokTutmaBirimiKodu,
                        KategoriId = x.Kategori.Id,
                        KategoriAdı = x.Kategori.KategoriAdi,
                        BirimFiyat = x.BirimFiyat,
                        MevcutStokMiktarı = x.MevcutStokMiktari,
                        YenidenSiparişSeviyesi = x.YenidenSiparisSeviyesi
                    }).ToList();

                    return Ok(iliskiliUrunler);
                }
            }
        }
    }
}

