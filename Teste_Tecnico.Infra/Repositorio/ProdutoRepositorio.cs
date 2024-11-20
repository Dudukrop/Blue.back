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
    public class ProdutoRepositorio : IProdutoRepositorio
    {
		private AplicacaoDbContexto _contexto;
		public ProdutoRepositorio(AplicacaoDbContexto contexto)
		{
			_contexto = contexto;
		}

		public async Task<Produto> CriarAsync(Produto produto)
		{
			_contexto.Add(produto);
			await _contexto.SaveChangesAsync();
			return produto;
		}

		public async Task<Produto> PegarPeloIdAsync(int? id)
		{
			return await _contexto.Produtos!.FindAsync(id);
		}

		public async Task<IEnumerable<Produto>> PegarProdutosAsync()
		{
			return await _contexto.Produtos!.ToListAsync();
		}

		public async Task<Produto> RemoverAsync(Produto produto)
		{
			_contexto.Remove(produto);
			await _contexto.SaveChangesAsync();
			return produto;
		}

		public async Task<Produto> AtualizarAsync(Produto produto)
		{
			_contexto.Update(produto);
			await _contexto.SaveChangesAsync();
			return produto;
		}
	}
}
