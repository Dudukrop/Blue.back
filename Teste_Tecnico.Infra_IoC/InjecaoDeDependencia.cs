using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Teste_Tecnico.Aplicacao.Interfaces;
using Teste_Tecnico.Aplicacao.Mapeamento;
using Teste_Tecnico.Aplicacao.Servico;
using Teste_Tecnico.Dominio.Interfaces;
using Teste_Tecnico.Infraestrutura.Contexto;
using Teste_Tecnico.Infraestrutura.Repositorio;

namespace Teste_Tecnico.Infra_IoC
{
    public static class InjecaoDeDependencia
    {
		public static IServiceCollection AdicionarInfraestrutura(this IServiceCollection servicos,
			IConfiguration configuracao)
		{
			//servicos.AddDbContext<AplicacaoDbContexto>(options =>
			// options.UseSqlServer(configuracao.GetConnectionString("DefaultConnection"
			//), b => b.MigrationsAssembly(typeof(AplicacaoDbContexto).Assembly.FullName)));

			servicos.AddDbContext<AplicacaoDbContexto>(options =>
			options.UseInMemoryDatabase("Teste_Tecnico"));

			servicos.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
			servicos.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
			servicos.AddScoped<IProdutoService, ProdutoServico>();
			servicos.AddScoped<ICategoriaServico, CategoriaServico>();

			servicos.AddAutoMapper(typeof(DominioParaDTOMapeamento));

			return servicos;
		}
	}
}
