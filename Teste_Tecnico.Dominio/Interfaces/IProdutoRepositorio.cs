using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Dominio.Entidades;

namespace Teste_Tecnico.Dominio.Interfaces
{
    public interface IProdutoRepositorio
    {
		Task<IEnumerable<Produto>> PegarProdutosAsync();
		Task<Produto> PegarPeloIdAsync(int? id);

		Task<Produto> CriarAsync(Produto produto);
		Task<Produto> AtualizarAsync(Produto produto);
		Task<Produto> RemoverAsync(Produto produto);
	}
}
