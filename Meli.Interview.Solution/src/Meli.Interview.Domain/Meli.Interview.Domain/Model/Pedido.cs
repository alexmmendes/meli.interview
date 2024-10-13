using Meli.Interview.Domain.DTO;

namespace Meli.Interview.Domain.Model
{
    public class Pedido(string cliente, DateTime dataPedido, decimal valorTotal, Endereco endereco)
    {
        public required string Cliente { get; set; } = cliente;
        public required DateTime DataPedido { get; set; } = dataPedido;
        public required decimal ValorTotal { get; set; } = valorTotal;
        public List<PedidoItem> Itens { get; set; } = new List<PedidoItem>();
        public required Endereco Endereco { get; set; } = endereco;
    }

    public class PedidoItem(string produto, decimal quantidade, decimal valorUnitario)
    {
        public required int PedidoId { get; set; }
        public required string Produto { get; set; } = produto;
        public required decimal Quantidade { get; set; } = quantidade;
        public required decimal ValorUnitario { get; set; } = valorUnitario;
    }

}
