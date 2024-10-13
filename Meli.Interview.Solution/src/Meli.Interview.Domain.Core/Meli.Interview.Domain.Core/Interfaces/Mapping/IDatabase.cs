namespace Meli.Interview.Domain.Core.Interfaces.Mapping
{
    /// <summary>
    /// Representa uma coleção de tabelas mapeadas.
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Nome do schema físico que este mapeamento representa.
        /// </summary>
        string PhysicalName { get; }

        /// <summary>Busca o mapeamento de uma entidade.</summary>
        /// <param name="entityType">O tipo da entidade.</param>
        ITable? GetTable(Type entityType);

        /// <summary>Busca o mapeamento de uma entidade.</summary>
        /// <typeparam name="T">O tipo da entidade.</typeparam>
        ITable<T>? GetTable<T>();
    }
}
