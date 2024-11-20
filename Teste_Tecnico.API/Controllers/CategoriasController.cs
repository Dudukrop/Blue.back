using Microsoft.AspNetCore.Mvc;
using Teste_Tecnico.Aplicacao.DTOs;
using Teste_Tecnico.Aplicacao.Interfaces;

namespace Teste_Tecnico.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
		private readonly ICategoriaServico _servico;
		public CategoriasController(ICategoriaServico servico)
		{
			_servico = servico;
        }

        [HttpGet]
		public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
		{
			var categorias = await _servico.PegarCategorias();
			if (categorias == null)
			{
				return NotFound("Categorias Não Encontradas.");
			}
			return Ok(categorias);
		}

        [HttpGet("{id:int}", Name = "PegarCategoria")]
		public async Task<ActionResult<CategoriaDTO>> Get(int id)
		{
			var category = await _servico.PegarPeloId(id);
			if (category == null)
			{
				return NotFound("Categorias Não Encontradas.");
            }
            return Ok(category);
        }

        [HttpPost]
		public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
		{
			if (categoriaDTO == null)
				return BadRequest("Categoria Inválida.");

			await _servico.Criar(categoriaDTO);

			return new CreatedAtRouteResult("PegarCategoria", new { id = categoriaDTO.Id },
			categoriaDTO);
        }

        [HttpPut]
		public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDTO)
		{
			if (id != categoriaDTO.Id)
				return BadRequest();

			if (categoriaDTO == null)
				return BadRequest();

			await _servico.Atualizar(categoriaDTO);
            return Ok(categoriaDTO);
		}

		[HttpDelete("{id:int}")]
		public async Task<ActionResult<CategoriaDTO>> Delete(int id)
		{
			var categoria = await _servico.PegarPeloId(id);
			if (categoria == null)
			{
				return NotFound("Categoria Não Encontrada.");
			}

			await _servico.Remover(id);

			return Ok(categoria);

		}
	}
}
