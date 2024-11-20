using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Dominio.Validacao;

namespace Teste_Tecnico.Dominio.Entidades
{
    public sealed class Produto : Entidade
    {
		public string Nome { get; private set; } = null!;
		public string? Descricao { get; private set; }
		public decimal Preco { get; private set; }
		public int Estoque { get; private set; }
		public string? Imagem { get; private set; }

		public int CategoriaId { get; set; }
		public Categoria Categoria { get; set; } = null!;

		public Produto(string nome, string descricao, decimal preco, int estoque, string imagem)
		{
			ValidateDomain(nome, descricao, preco, estoque, imagem);
		}

		public Produto(int id, string nome, string descricao, decimal preco, int estoque, string imagem)
		{
			ValidacaoDominio.Quando(id < 0, "Id Inválido.");
			Id = id;
			ValidateDomain(nome, descricao, preco, estoque, imagem);
		}

		public void Update(string nome, string descricao, decimal preco, int estoque, string imagem, int categoriaId)
		{
			ValidateDomain(nome, descricao, preco, estoque, imagem);
			CategoriaId = categoriaId;
		}

		private void ValidateDomain(string nome, string descricao, decimal preco, int estoque, string imagem)
		{
			ValidacaoDominio.Quando(string.IsNullOrEmpty(nome),
				"Campo Nome é Necessário.");

			ValidacaoDominio.Quando(nome.Length < 3,
				"Campo Nome Inválido, Minímo de 3 Caracteres.");

			ValidacaoDominio.Quando(string.IsNullOrEmpty(descricao),
				"Campo Descrição é Necessário.");

			ValidacaoDominio.Quando(descricao.Length < 5,
				"Campo Descrição Inválido, Minímo de 5 Caracteres.");

			ValidacaoDominio.Quando(preco < 0, "Preço Inválido.");

			ValidacaoDominio.Quando(estoque < 0, "Preço de Estoque Inválido.");

			ValidacaoDominio.Quando(imagem?.Length > 250,
				"Campo Imagem Inválido, Maximo de 250 Caracteres.");

			Nome = nome;
			Descricao = descricao;
			Preco = preco;
			Estoque = estoque;
			Imagem = imagem;
		}
	}
}
