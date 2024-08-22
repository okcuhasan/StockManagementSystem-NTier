using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StokTakipSistemi.BLL.ManagerServices.Interfaces;
using StokTakipSistemi.ENTITIES.DataTransferObjects;
using StokTakipSistemi.ENTITIES.Entity;

namespace StokTakipSistemi.RESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        IKategoriManager _kategoriManager;
        public KategoriController(IKategoriManager kategoriManager)
        {
            _kategoriManager = kategoriManager;
        }

        [HttpGet]
        public async Task<IActionResult> KategorileriListele()
        {
            IQueryable<Kategori> kategoriler = _kategoriManager.GetAllQueryableBll();
            return Ok(await kategoriler.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> KategoriGetir(int id)
        {
            if(id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Kategori kategori = await _kategoriManager.GetByIdAsyncBll(id);
                if(kategori == null)
                {
                    return NotFound("Kategori bulunamadı!");
                }
                else
                {
                    return Ok(kategori);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> KategoriEkle(KategoriDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                Kategori kategori = new Kategori
                {
                    KategoriAdi = dTO.KategoriAdi,
                    KategoriAciklamasi = dTO.KategoriAciklamasi
                };
                string mesaj = await _kategoriManager.AddAsyncBll(kategori);
                return Ok(mesaj);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> KategoriGuncelle(int id,KategoriDTO dTO)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else if(!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                Kategori kategori = await _kategoriManager.GetByIdAsyncBll(id);
                if(kategori == null)
                {
                    return NotFound("Kategori bulunamadı");
                }
                else
                {
                    kategori.KategoriAdi = dTO.KategoriAdi;
                    kategori.KategoriAciklamasi = dTO.KategoriAciklamasi;

                    string mesaj = await _kategoriManager.UpdateBll(kategori);
                    return Ok(mesaj);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> KategoriSil(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Kategori kategori = await _kategoriManager.GetByIdAsyncBll(id);
                if (kategori == null)
                {
                    return NotFound("Kategori bulunamadı");
                }
                else
                {
                    string mesaj = await _kategoriManager.DeleteBll(kategori);
                    return Ok(mesaj);
                }
            }
        }

        [HttpGet("KategoriAra")]
        public async Task<IActionResult> KategoriAra(string kategoriBilgisi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                IQueryable<Kategori> kategori = _kategoriManager.WhereQueryableBll(x => x.KategoriAdi == kategoriBilgisi || x.KategoriAciklamasi == kategoriBilgisi);
                if(!kategori.Any()) // Any metodu sorgu çalıştırılmadan önce ilgili veri kümesi var mı yok mu bunu kontrol eder bu nedenle iqueryable ile kullanılır, filtreye uyan veri veya veriler var mı anlamında.
                {
                    return NotFound("Kategori bulunamadı");
                }
                else
                {
                    return Ok(await kategori.ToListAsync());
                }
            }
        }
    }
}
