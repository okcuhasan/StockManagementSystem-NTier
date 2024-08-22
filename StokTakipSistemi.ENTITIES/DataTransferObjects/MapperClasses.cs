using AutoMapper;
using StokTakipSistemi.ENTITIES.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.ENTITIES.DataTransferObjects
{
    public class MapperClasses : Profile
    {
        public MapperClasses() 
        {
            CreateMap<Kategori, KategoriDTO>().ReverseMap();
            CreateMap<Urun, UrunDTO>().ReverseMap();
            CreateMap<Musteri, MusteriDTO>().ReverseMap();
            CreateMap<Tedarikci, TedarikciDTO>().ReverseMap();
            CreateMap<Siparis, SiparisDTO>().ReverseMap();
        }
    }
}
