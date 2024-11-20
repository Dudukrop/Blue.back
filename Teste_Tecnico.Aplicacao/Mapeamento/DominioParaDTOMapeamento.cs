using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Tecnico.Aplicacao.DTOs;
using Teste_Tecnico.Dominio.Entidades;

namespace Teste_Tecnico.Aplicacao.Mapeamento
{
    public class DominioParaDTOMapeamento : Profile
    {
		public DominioParaDTOMapeamento()
        {
			CreateMap<Categoria, CategoriaDTO>().ReverseMap();
			CreateMap<Produto, ProdutoDTO>().ReverseMap();
		}
	}
}
