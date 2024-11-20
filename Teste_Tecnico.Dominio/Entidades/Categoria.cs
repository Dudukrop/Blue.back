using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Dominio.Validacao;

namespace Teste_Tecnico.Dominio.Entidades
{
    public sealed class Categoria : Entidade
    {
		public string Nome { get; private set; } = null!;
		public ICollection<Produto>? Produtos { get; set; }

		public Categoria(string nome)
		{
			ValidateDomain(nome);
		}

		public Categoria(int id, string nome)
		{
			ValidacaoDominio.Quando(id < 0, "Id Inválido.");
			Id = id;
			ValidateDomain(nome);
		}

		public void Update(string nome)
		{
			ValidateDomain(nome);
		}

		private void ValidateDomain(string nome)
		{
			ValidacaoDominio.Quando(string.IsNullOrEmpty(nome),
				"Campo Nome é Necessário.");

			ValidacaoDominio.Quando(nome.Length < 3,
			   "Campo Nome Inválido, Minímo de 3 Caracteres.");

			Nome = nome;
		}
	}
}
