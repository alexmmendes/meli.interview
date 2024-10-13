using Meli.Interview.Domain.DTO;
using Meli.Interview.Domain.Interfaces.Repository;
using Meli.Interview.Domain.Model;
using Meli.Interview.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Meli.Interview.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly ExpressContext _dbContext;
        private bool disposedValue;

        public PedidoRepository(ExpressContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task SalvarPedido(Pedido pedido)
        {
            _dbContext.Pedido.Add(pedido);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Pedido>> ObterPedidos()
        {
            return await _dbContext.Pedido.ToListAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
