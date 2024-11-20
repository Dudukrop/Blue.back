using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Teste_Tecnico.Aplicacao.DTOs;
using Teste_Tecnico.Aplicacao.Interfaces;

namespace Teste_Tecnico.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutosController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _service.PegarProdutos();
            if (produtos == null)
            {
                return NotFound("Produtos Não Encontrados.");
            }
            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "PegarProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produto = await _service.PegarPeloId(id);
            if (produto == null)
            {
                return NotFound("Produto Não Encontrados.");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDto)
        {
            if (produtoDto == null)
                return BadRequest("Produto Inválido.");

            await _service.Criar(produtoDto);

            return new CreatedAtRouteResult("PegarProduto",
                new { id = produtoDto.Id }, produtoDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDto)
        {
            if (id != produtoDto.Id)
            {
                return BadRequest("Produto Inválido.");
            }

            if (produtoDto == null)
                return BadRequest("Produto Inválido.");

            await _service.Atualizar(produtoDto);
            return Ok(produtoDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> Delete(int id)
        {
            var produtoDto = await _service.PegarPeloId(id);

            if (produtoDto == null)
            {
                return NotFound("Produto Não Encontrado.");
            }

            await _service.Remover(id);

            return Ok(produtoDto);
        }
    }
}
