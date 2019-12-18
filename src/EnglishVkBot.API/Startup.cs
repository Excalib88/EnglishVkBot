using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EnglishVkBot.Abstractions;
using EnglishVkBot.Domain;
using EnglishVkBot.Translator;
using EnglishVkBot.DataAccess;
using EnglishVkBot.Domain.Mappings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.HttpOverrides;

namespace EnglishVkBot.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);
            services.AddDatabase(Configuration);
            Mapper.Initialize(cfg => cfg.AddProfiles(typeof(TranslateTextProfile).Assembly));
            services.AddScoped<IMapper>(p => new Mapper(Mapper.Configuration));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Translator API",
                    Description = "ASP.NET Core Web API"
                });
            });
        
            
            services.AddCors();
            services.AddSingleton<ITranslator, TextTranslator>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            //serviceProvider.GetService<DataContext>().Database.Migrate();           
            app.UseCors(b => {
                b.AllowAnyOrigin();
                b.AllowAnyMethod();
                b.AllowAnyHeader();
            });
            
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Translator API V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseMvc();
        }
    }
}