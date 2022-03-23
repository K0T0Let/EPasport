using EPasport.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EPasport
{
    public class Startup
    {
        //Создание и установка через конструктор объекта конфигурации
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Подключение сервиса контекста БД
            string connecting = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<EPasportContext>(options => options.UseSqlServer(connecting));
            //Подключение MVC
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Вывод страници ошибки в случае если выбран режим разработки
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Подключение статических файлов
            app.UseStaticFiles();
            //Подключение маршрутизации
            app.UseRouting();

            //Установка маршрутизации
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern:"{controller=Home}/{action=Index}");
            });
        }
    }
}
