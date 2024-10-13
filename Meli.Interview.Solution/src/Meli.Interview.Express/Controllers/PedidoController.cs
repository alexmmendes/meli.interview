using Meli.Interview.Application.Interfaces.Pedido;
using Meli.Interview.Domain.DTO;
using Meli.Interview.Domain.Model;
using Microsoft.AspNetCore.Mvc;

namespace Meli.Interview.Express.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : BaseController
    {
        private readonly IPedidoService _pedidoService;

        public PedidoController(IPedidoService service)
            => _pedidoService = service ?? throw new ArgumentNullException(nameof(service));


        [HttpPost]
        public async Task<ActionResult<Pedido>> ProcessarPedido(PedidoDTO pedido)
        {
            var result = await _pedidoService.ProcessarPedido(pedido);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> ConsultarPedidos()
        {
            var result = await _pedidoService.ConsultarPedidos();
            return Ok(result);
        }
    }
}
