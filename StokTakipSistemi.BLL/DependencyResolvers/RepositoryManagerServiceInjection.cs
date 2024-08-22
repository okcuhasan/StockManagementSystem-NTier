using Microsoft.Extensions.DependencyInjection;
using StokTakipSistemi.BLL.ManagerServices.Implementations;
using StokTakipSistemi.BLL.ManagerServices.Interfaces;
using StokTakipSistemi.DAL.Repositories.Implementations;
using StokTakipSistemi.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StokTakipSistemi.BLL.DependencyResolvers
{
    public static class RepositoryManagerServiceInjection
    {
        public static IServiceCollection AddRepositoryManagerServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IKategoriRepository, KategoriRepository>();
            services.AddScoped<IMusteriRepository, MusteriRepository>();
            services.AddScoped<ISiparisDetayRepository, SiparisDetayRepository>();
            services.AddScoped<ISiparisRepository, SiparisRepository>();
            services.AddScoped<IStokHareketRepository, StokHareketRepository>();
            services.AddScoped<ITedarikciRepository, TedarikciRepository>();
            services.AddScoped<IUrunRepository, UrunRepository>();
            services.AddScoped(typeof(IManager<>), typeof(BaseManager<>));
            services.AddScoped<IKategoriManager, KategoriManager>();
            services.AddScoped<IMusteriManager, MusteriManager>();
            services.AddScoped<ISiparisDetayManager, SiparisDetayManager>();
            services.AddScoped<ISiparisManager, SiparisManager>();
            services.AddScoped<IStokHareketManager, StokHareketManager>();
            services.AddScoped<ITedarikciManager, TedarikciManager>();
            services.AddScoped<IUrunManager, UrunManager>();

            return services;
        }
    }
}
