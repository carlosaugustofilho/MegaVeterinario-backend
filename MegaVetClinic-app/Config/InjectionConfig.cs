﻿using MegaVetClinic.Business.Interfaces;
using MegaVetClinic.Business.Service;
using MegaVetClinic.Repository.Interfaces;

namespace MegaVetClinic_app.Config
{
    public static class InjectionConfig
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddHttpClient();

            // Services
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IFuncionarioService, FuncionarioService>();



            //Repositories
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();


        }
    }
}
