using Meli.Interview.Domain.Core.DependencyInjection;
using Meli.Interview.Domain.Core.Interfaces.Mapping;

namespace Meli.Interview.Infra.Data.Mappings.Tables
{
    [SingletonService]
    public sealed class Database : IDatabase
    {
        private readonly IReadOnlyCollection<ITable> tables;
        private readonly IReadOnlyDictionary<Type, ITable> tableDict;

        // TODO: Ler de uma configuração
        public string PhysicalName => "dbo";

        public Database(IEnumerable<ITable> tables)
        {
            this.tables = tables.ToList();
            tableDict = this.tables
                .Where(t => t.EntityType != null)
                .ToDictionary(t => t.EntityType!);
        }

        public ITable? GetTable(Type entityType)
            => tableDict[entityType];

        public ITable<T>? GetTable<T>()
            => GetTable(typeof(T)) as ITable<T>;
    }
}
