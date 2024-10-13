namespace Meli.Interview.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();

        Task CommitAsync();
    }
}
