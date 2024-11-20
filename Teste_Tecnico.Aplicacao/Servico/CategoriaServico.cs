using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Aplicacao.DTOs;
using Teste_Tecnico.Aplicacao.Interfaces;
using Teste_Tecnico.Dominio.Entidades;
using Teste_Tecnico.Dominio.Interfaces;

namespace Teste_Tecnico.Aplicacao.Servico
{
    public class CategoriaServico : ICategoriaServico
    {
		private ICategoriaRepositorio _repositorio;
		private readonly IMapper _mapper;
		public CategoriaServico(ICategoriaRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
            _mapper = mapper;
        }

		public async Task<IEnumerable<CategoriaDTO>> PegarCategorias()
		{
			var entidades = await _repositorio.PegarCategoriasAsync();
			return _mapper.Map<IEnumerable<CategoriaDTO>>(entidades);
		}

		public async Task<CategoriaDTO> PegarPeloId(int? id)
        {
			var entidade = await _repositorio.PegarPeloIdAsync(id);
			return _mapper.Map<CategoriaDTO>(entidade);
		}

		public async Task Criar(CategoriaDTO categoriaDto)
		{
			var entidade = _mapper.Map<Categoria>(categoriaDto);
			await _repositorio.CriarAsync(entidade);
			categoriaDto.Id = entidade.Id;
		}

		public async Task Atualizar(CategoriaDTO categoriaDTO)
		{
			var entidade = _mapper.Map<Categoria>(categoriaDTO);
			await _repositorio.AtualizarAsync(entidade);
		}

		public async Task Remover(int? id)
		{
			var entidade = _repositorio.PegarPeloIdAsync(id).Result;
			await _repositorio.RemoverAsync(entidade);
		}
	}
}
