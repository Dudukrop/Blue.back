using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Tecnico.Aplicacao.DTOs
{
    public class CategoriaDTO
    {
		public int Id { get; set; }
		[Required(ErrorMessage = "O Campo Nome é Necessário.")]
		[MinLength(3)]
		[MaxLength(100)]
		public string? Nome { get; set; }
	}
}
