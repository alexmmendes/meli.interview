using Meli.Interview.Application.Interfaces.Produto;
using Microsoft.AspNetCore.Mvc;

namespace Meli.Interview.Express.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : BaseController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService service)
            => _produtoService = service ?? throw new ArgumentNullException(nameof(service));

        [HttpPost]
        public async Task<ActionResult<Produto>> CadastrarProduto(ProdutoDTO produto)
        {
            var result = await _produtoService.CadastrarProduto(produto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Produto>>> ConsultarProdutos()
        {
            var result = await _produtoService.ConsultarProdutos();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> ConsultarProduto(int id)
        {
            var result = await _produtoService.ConsultarProduto(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produto>> AtualizarProduto(int id, ProdutoDTO produto)
        {
            var result = await _produtoService.AtualizarProduto(id, produto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarProduto(int id)
        {
            await _produtoService.DeletarProduto(id);
            return NoContent();
        }
    }
}
