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
    public class ProdutoServico : IProdutoService
    {
		private readonly IProdutoRepositorio _repositorio;
		private readonly IMapper _mapper;
		public ProdutoServico(IProdutoRepositorio repositorio, IMapper mapper)
		{
			_repositorio = repositorio;
			_mapper = mapper;
        }

		public async Task<IEnumerable<ProdutoDTO>> PegarProdutos()
		{
			var produtos = await _repositorio.PegarProdutosAsync();
			return _mapper.Map<IEnumerable<ProdutoDTO>>(produtos);
		}

		public async Task<ProdutoDTO> PegarPeloId(int? id)
		{
			var produto = await _repositorio.PegarPeloIdAsync(id);
			return _mapper.Map<ProdutoDTO>(produto);
		}

		public async Task Criar(ProdutoDTO produtoDTO)
		{
			var produto = _mapper.Map<Produto>(produtoDTO);
			await _repositorio.CriarAsync(produto);
			produtoDTO.Id = produto.Id;
		}

		public async Task Atualizar(ProdutoDTO produtoDTO)
		{
			var produto = _mapper.Map<Produto>(produtoDTO);
			await _repositorio.AtualizarAsync(produto);
		}

		public async Task Remover(int? id)
		{
			var categoria = _repositorio.PegarPeloIdAsync(id).Result;
			await _repositorio.RemoverAsync(categoria);
		}
	}
}
