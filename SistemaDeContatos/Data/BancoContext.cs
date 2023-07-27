using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;
using SistemaDeContatos.Models;

namespace SistemaDeContatos.Data
{
    // A classe BancoContext é uma classe especial que representa o contexto do banco de dados.
    // Ela herda da classe DbContext do Entity Framework, que fornece funcionalidades para acessar e manipular os dados do banco de dados.
    // O BancoContext atua como uma ponte entre o código da aplicação e o banco de dados, permitindo consultas, inserções, atualizações e exclusões de dados.

    public class BancoContext : DbContext
    {
        //Configuração padrão
        /*
        O construtor da classe BancoContext é responsável por inicializar a instância do contexto do banco de dados.
        Ele recebe um parâmetro do tipo DbContextOptions<BancoContext>, que contém as opções de configuração do contexto do banco de dados.
        Ao chamar "base(options)", estamos passando essas opções para o construtor da classe base DbContext, para configurar corretamente o contexto do banco de dados com base nessas opções.
        Essa configuração permite que o BancoContext se conecte ao banco de dados e estabeleça a comunicação para executar operações de consulta e modificação nos dados.
        */
        public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

        //Configurar as tabelas que estarão nesse BancoContext
        /*
           A propriedade Contatos representa a tabela "Contatos" no contexto do banco de dados.
           Permite acessar e manipular os registros da tabela por meio do contexto do banco de dados.
        */
        public DbSet<ContatoModel> Contatos { get; set; }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
