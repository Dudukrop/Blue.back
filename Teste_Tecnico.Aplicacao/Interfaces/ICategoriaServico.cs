using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Aplicacao.DTOs;

namespace Teste_Tecnico.Aplicacao.Interfaces
{
    public interface ICategoriaServico
    {
		Task<IEnumerable<CategoriaDTO>> PegarCategorias();
		Task<CategoriaDTO> PegarPeloId(int? id);
		Task Criar(CategoriaDTO categoriaDto);
		Task Atualizar(CategoriaDTO categoriaDto);
		Task Remover(int? id);
	}
}
