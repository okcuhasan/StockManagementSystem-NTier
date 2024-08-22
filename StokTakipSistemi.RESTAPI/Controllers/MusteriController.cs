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
    public class MusteriController : ControllerBase
    {
        IMusteriManager _musteriManager;
        IMapper _mapper;
        public MusteriController(IMusteriManager musteriManager, IMapper mapper)
        {
            _musteriManager = musteriManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MusterileriListele()
        {
            IQueryable<Musteri> musteriler = _musteriManager.GetAllQueryableBll();
            return Ok(await musteriler.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> MusteriGetir(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Musteri musteri = await _musteriManager.GetByIdAsyncBll(id);
                if (musteri == null)
                {
                    return NotFound("Müşteri bulunamadı!");
                }
                else
                {
                    return Ok(musteri);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> MusteriEkle(MusteriDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                Musteri musteri = _mapper.Map<Musteri>(dTO);
                string mesaj = await _musteriManager.AddAsyncBll(musteri);
                
                return Ok(mesaj);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> MusteriGuncelle(int id, MusteriDTO dTO)
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
                Musteri musteri = await _musteriManager.GetByIdAsyncBll(id);
                if (musteri == null)
                {
                    return NotFound("Müşteri bulunamadı");
                }
                else
                {
                    _mapper.Map(dTO, musteri);
                    string mesaj = await _musteriManager.UpdateBll(musteri);

                    return Ok(mesaj);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> MusteriSil(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Musteri musteri = await _musteriManager.GetByIdAsyncBll(id);
                if (musteri == null)
                {
                    return NotFound("Müşteri bulunamadı");
                }
                else
                {
                    string mesaj = await _musteriManager.DeleteBll(musteri);
                    return Ok(mesaj);
                }
            }
        }

        [HttpGet("MusteriAra")]
        public async Task<IActionResult> MusteriAra(string musteriBilgisi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                IQueryable<Musteri> musteri = _musteriManager.WhereQueryableBll(x => x.MusteriAdi == musteriBilgisi);
                if (!musteri.Any()) // Any metodu sorgu çalıştırılmadan önce ilgili veri kümesi var mı yok mu bunu kontrol eder bu nedenle iqueryable ile kullanılır, filtreye uyan veri veya veriler var mı anlamında.
                {
                    return NotFound("Müşteri bulunamadı");
                }
                else
                {
                    return Ok(await musteri.ToListAsync());
                }
            }
        }
    }
}
