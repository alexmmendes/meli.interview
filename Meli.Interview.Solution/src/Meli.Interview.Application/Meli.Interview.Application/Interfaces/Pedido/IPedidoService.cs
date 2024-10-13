using Meli.Interview.Domain.DTO;

namespace Meli.Interview.Application.Interfaces.Pedido
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoDTO>> ConsultarPedidos();
        Task<PedidoDTO> ProcessarPedido(PedidoDTO pedido);
    }
}
