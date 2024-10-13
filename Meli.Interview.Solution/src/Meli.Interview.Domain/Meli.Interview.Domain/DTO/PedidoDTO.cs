using Meli.Interview.Domain.Model;

namespace Meli.Interview.Domain.DTO
{
    public class PedidoDTO(string cliente, DateTime dataPedido, decimal valorTotal, Endereco endereco)
    {
        public required string Cliente { get; set; } = cliente;
        public required DateTime DataPedido { get; set; } = dataPedido;
        public required decimal ValorTotal { get; set; } = valorTotal;
        public required List<PedidoItemDTO> Itens { get; set; } = new List<PedidoItemDTO>();
        public required Endereco Endereco { get; set; } = endereco;
    }

    public class PedidoItemDTO(string produto, decimal quantidade, decimal valorUnitario)
    {
        public required int PedidoId { get; set; }
        public required string Produto { get; set; } = produto;
        public required decimal Quantidade { get; set; } = quantidade;
        public required decimal ValorUnitario { get; set; } = valorUnitario;
    }
}
