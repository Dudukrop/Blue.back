using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Teste_Tecnico.Dominio.Entidades;

namespace Teste_Tecnico.Aplicacao.DTOs
{
    public class ProdutoDTO
    {
		public int Id { get; set; }

		[Required(ErrorMessage = "O Campo Nome é Necessário.")]
		[MinLength(3)]
		[MaxLength(100)]
		[DisplayName("Nome")]
		public string? Nome { get; set; }

		[Required(ErrorMessage = "O Campo Descrição é Necessário.")]
		[MinLength(5)]
		[MaxLength(200)]
		[DisplayName("Descricao")]
		public string? Descricao { get; set; }

		[Required(ErrorMessage = "O Campo Preço é Necessário.")]
		[Column(TypeName = "decimal(18,2)")]
		[DisplayFormat(DataFormatString = "{0:C2}")]
		[DataType(DataType.Currency)]
		[DisplayName("Preco")]
		public decimal Preco { get; set; }

		[Required(ErrorMessage = "O Campo Estoque é Necessário.")]
		[Range(1, 9999)]
		[DisplayName("Estoque")]
		public int Estoque { get; set; }

		[MaxLength(250)]
		[DisplayName("Imagem do Produto")]
		public string? Imagem { get; set; }

		[JsonIgnore]
		public Categoria? Category { get; set; }

		[DisplayName("Categorias")]
		public int CategoriaId { get; set; }
	}
}
