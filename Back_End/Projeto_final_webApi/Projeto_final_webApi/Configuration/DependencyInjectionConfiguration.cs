using Microsoft.Extensions.DependencyInjection;
using projeto_final_webApi.Interfaces;
using projeto_final_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projeto_final_webApi.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void adddependencyinjectionconfiguration(this IServiceCollection services)
        {
        
            AddRepositories(services);
        
        }
        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<ISetorRepository, SetorRepository>();
            services.AddScoped<IChamadoRepository, ChamadoRepository>();
            services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }
     
    }
}
