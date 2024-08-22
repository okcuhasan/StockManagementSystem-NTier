using AutoMapper;
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
    public class TedarikciController : ControllerBase
    {
        ITedarikciManager _tedarikciManager;
        IMapper _mapper;
        public TedarikciController(ITedarikciManager tedarikciManager, IMapper mapper)
        {
            _tedarikciManager = tedarikciManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> TedarikcileriListele()
        {
            IQueryable<Tedarikci> tedarikciler = _tedarikciManager.GetAllQueryableBll();
            return Ok(await tedarikciler.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> TedarikciGetir(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Tedarikci tedarikci = await _tedarikciManager.GetByIdAsyncBll(id);
                if (tedarikci == null)
                {
                    return NotFound("Tedarikçi bulunamadı!");
                }
                else
                {
                    return Ok(tedarikci);
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> TedarikciEkle(TedarikciDTO dTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                Tedarikci tedarikci = _mapper.Map<Tedarikci>(dTO);
                string mesaj = await _tedarikciManager.AddAsyncBll(tedarikci);

                return Ok(mesaj);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> TedarikciGuncelle(int id, TedarikciDTO dTO)
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
                Tedarikci tedarikci = await _tedarikciManager.GetByIdAsyncBll(id);
                if (tedarikci == null)
                {
                    return NotFound("Tedarikçi bulunamadı");
                }
                else
                {
                    _mapper.Map(dTO, tedarikci);
                    string mesaj = await _tedarikciManager.UpdateBll(tedarikci);

                    return Ok(mesaj);
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> TedarikciSil(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID bilgisi 0'dan büyük olmalıdır!");
            }
            else
            {
                Tedarikci tedarikci = await _tedarikciManager.GetByIdAsyncBll(id);
                if (tedarikci == null)
                {
                    return NotFound("Tedarikçi bulunamadı");
                }
                else
                {
                    string mesaj = await _tedarikciManager.DeleteBll(tedarikci);
                    return Ok(mesaj);
                }
            }
        }

        [HttpGet("TedarikciAra")]
        public async Task<IActionResult> TedarikciAra(string tedarikciBilgisi)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Hatalı veri girişi yaptınız!");
            }
            else
            {
                IQueryable<Tedarikci> tedarikci = _tedarikciManager.WhereQueryableBll(x => x.TedarikciAdi == tedarikciBilgisi);
                if (!tedarikci.Any()) // Any metodu sorgu çalıştırılmadan önce ilgili veri kümesi var mı yok mu bunu kontrol eder bu nedenle iqueryable ile kullanılır, filtreye uyan veri veya veriler var mı anlamında.
                {
                    return NotFound("Tedarikçi bulunamadı");
                }
                else
                {
                    return Ok(await tedarikci.ToListAsync());
                }
            }
        }
    }
}
