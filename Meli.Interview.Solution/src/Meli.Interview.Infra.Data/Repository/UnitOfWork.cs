using Meli.Interview.Domain.Core.DependencyInjection;
using Meli.Interview.Domain.Core.Interfaces;
using Meli.Interview.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Nito.AsyncEx.Synchronous;

namespace Meli.Interview.Infra.Data.Repository
{
    [ScopedService]
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly ExpressContext _context;

        public UnitOfWork(ExpressContext context)
        {
            _context = context;
        }

        public void Commit() => CommitAsync().WaitAndUnwrapException();

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
            Detach();
        }

        private void Detach()
        {
            var changedEntriesCopy = _context.ChangeTracker.Entries().ToList();

            foreach (var entry in changedEntriesCopy)
                entry.State = EntityState.Detached;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
