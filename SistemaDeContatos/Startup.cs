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
            // Configuração do Entity Framework SQL Server:
            // Adiciona o provedor do SQL Server ao serviço de Entity Framework.
            // Em seguida, configura o contexto do banco de dados para usar o BancoContext.
            services.AddEntityFrameworkSqlServer().AddDbContext<BancoContext>(o => o.UseSqlServer(Configuration.GetConnectionString("DataBase")));

            //Para a criação de sessão na aplicação
            //Toda vez que chamar a interface IHttpContextAccessor, quero que implemente a classe HttpContextAccessor.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Toda a vez que ele chamar a ISessao, quero que implemente a classe Sessao
            services.AddScoped<ISessao, Sessao>();

            //configurando o serviço de sessão 
            services.AddSession(o =>
            {
                //o cookie só pode ser acessado por meio de solicitações HTTP e não por JavaScript no cliente
                o.Cookie.HttpOnly = true;
                //o cookie é essencial para o funcionamento do aplicativo e que ele deve ser sempre enviado nas solicitações, mesmo que o usuário tenha escolhido não permitir cookies.
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

            //Adição do middewere para a utilização de sessão na aplicação.
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
