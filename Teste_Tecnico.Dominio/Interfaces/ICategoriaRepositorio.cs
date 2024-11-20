using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Dominio.Entidades;

namespace Teste_Tecnico.Dominio.Interfaces
{
    public interface ICategoriaRepositorio
    {
		Task<IEnumerable<Categoria>> PegarCategoriasAsync();
		Task<Categoria> PegarPeloIdAsync(int? id);

		Task<Categoria> CriarAsync(Categoria categoria);
		Task<Categoria> AtualizarAsync(Categoria categoria);
		Task<Categoria> RemoverAsync(Categoria categoria);
	}
}
