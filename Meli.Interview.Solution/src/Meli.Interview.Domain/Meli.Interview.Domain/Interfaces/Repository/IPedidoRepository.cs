using Meli.Interview.Domain.DTO;
using Meli.Interview.Domain.Model;

namespace Meli.Interview.Domain.Interfaces.Repository
{
    public interface IPedidoRepository : IDisposable
    {
        Task<List<Pedido>> ObterPedidos();
        Task SalvarPedido(Pedido pedido);
    }
}
