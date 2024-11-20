using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Dominio.Entidades;
using Teste_Tecnico.Dominio.Interfaces;
using Teste_Tecnico.Infraestrutura.Contexto;

namespace Teste_Tecnico.Infraestrutura.Repositorio
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
		private AplicacaoDbContexto _contexto;
		public CategoriaRepositorio(AplicacaoDbContexto contexto)
		{
			_contexto = contexto;
		}

		public async Task<Categoria> CriarAsync(Categoria categoria)
		{
			_contexto.Add(categoria);
			await _contexto.SaveChangesAsync();
			return categoria;
		}

		public async Task<Categoria> PegarPeloIdAsync(int? id)
		{
			var categoria = await _contexto.Categorias!.FindAsync(id);
			return categoria!;
		}

		public async Task<IEnumerable<Categoria>> PegarCategoriasAsync()
		{
			return await _contexto.Categorias!.OrderBy(c => c.Nome).ToListAsync();
		}

		public async Task<Categoria> RemoverAsync(Categoria categoria)
		{
			_contexto.Remove(categoria);
			await _contexto.SaveChangesAsync();
			return categoria;
		}

		public async Task<Categoria> AtualizarAsync(Categoria categoria)
		{
			_contexto.Update(categoria);
			await _contexto.SaveChangesAsync();
			return categoria;
		}
	}
}
