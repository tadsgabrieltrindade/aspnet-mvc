using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SistemaDeContatos.Data;
using SistemaDeContatos.Helper;
using SistemaDeContatos.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaDeContatos
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
            services.AddControllersWithViews();
            // Configura��o do Entity Framework SQL Server:
            // Adiciona o provedor do SQL Server ao servi�o de Entity Framework.
            // Em seguida, configura o contexto do banco de dados para usar o BancoContext.
            services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase")));

            //Para a cria��o de sess�o na aplica��o
            //Toda vez que chamar a interface IHttpContextAccessor, quero que implemente a classe HttpContextAccessor.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Toda a vez que ele chamar a ISessao, quero que implemente a classe Sessao
            services.AddScoped<ISessao, Sessao>();

            //configurando o servi�o de sess�o 
            services.AddSession(o =>
            {
                //o cookie s� pode ser acessado por meio de solicita��es HTTP e n�o por JavaScript no cliente
                o.Cookie.HttpOnly = true;
                //o cookie � essencial para o funcionamento do aplicativo e que ele deve ser sempre enviado nas solicita��es, mesmo que o usu�rio tenha escolhido n�o permitir cookies.
                o.Cookie.IsEssential = true;
            });

            services.AddScoped<IContatoRepositorio, ContatoRepositorio>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>(); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //Adi��o do middewere para a utiliza��o de sess�o na aplica��o.
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Index}/{id?}");
            });
        }
    }
}
