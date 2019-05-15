using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnglishVkBot.Abstractions;
using EnglishVkBot.Translator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using VkNet;
using VkNet.Abstractions;
using VkNet.Model;

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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            services.AddSingleton<IVkApi>(sp => {
                var api = new VkApi();
                api.Authorize(new ApiAuthParams{ AccessToken = Configuration["Config:VkAccessToken"] });
                return api;
            });
            services.AddSingleton<ITranslator>(sp => new TextTranslator(Configuration["Config:YandexAccessToken"]));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            
            loggerFactory.AddConsole();
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}