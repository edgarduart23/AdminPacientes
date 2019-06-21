using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminPacientes.Data.Interfaces;
using AdminPacientes.Data.Repositories;
using AdminPacientes.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AdminPacientes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AdminContexto>(opts => opts.UseSqlServer(Configuration["ConnectionString:AdministracionDB"]));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IObraSocialRepository, ObraSocialRepository>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();
            services.AddScoped<IDomicilioRepository, DomicilioRepository>();
            services.AddScoped<ITutorRepository, TutorRepository>();
            
            services.AddMvc().AddJsonOptions(ConfigurationJson);
            
            //services.AddMvc(options =>
            //{
            //    options.ReturnHttpNotAcceptable = true;
            //});
        }

        private void ConfigurationJson(MvcJsonOptions obj)
        {
            obj.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
