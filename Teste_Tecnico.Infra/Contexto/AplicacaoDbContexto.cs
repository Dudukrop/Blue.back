using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Dominio.Entidades;

namespace Teste_Tecnico.Infraestrutura.Contexto
{
    public class AplicacaoDbContexto : DbContext
    {
		public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> options)
		: base(options)
		{ }

		public DbSet<Categoria>? Categorias { get; set; }
		public DbSet<Produto>? Produtos { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.ApplyConfigurationsFromAssembly(typeof(AplicacaoDbContexto).Assembly);
		}
	}
}
