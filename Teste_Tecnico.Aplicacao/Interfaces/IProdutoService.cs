using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Aplicacao.DTOs;

namespace Teste_Tecnico.Aplicacao.Interfaces
{
    public interface IProdutoService
    {
		Task<IEnumerable<ProdutoDTO>> PegarProdutos();
		Task<ProdutoDTO> PegarPeloId(int? id);

		Task Criar(ProdutoDTO produtoDto);
		Task Atualizar(ProdutoDTO produtoDto);
		Task Remover(int? id);
	}
}
