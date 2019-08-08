using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserRegistration.Repository;
using AutoMapper;
using UserRegistration.Service;
using Microsoft.OpenApi.Models;

namespace UserRegistration.Api
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
            services.AddTransient<UserRepository, UserRepository>();
            services.AddTransient<UserService, UserService>();

            services.AddSwaggerGen();
            // Configurando o serviço de documentação do Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UserRegistration API", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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

            app.UseStaticFiles();

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "UserRegistration API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
