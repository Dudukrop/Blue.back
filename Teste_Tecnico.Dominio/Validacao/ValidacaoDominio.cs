using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Tecnico.Dominio.Validacao
{
    public class ValidacaoDominio : Exception
    {
		public ValidacaoDominio(string erro) : base(erro)
		{ }

		public static void Quando(bool temErro, string erro)
		{
			if (temErro)
				throw new ValidacaoDominio(erro);
		}
	}
}
