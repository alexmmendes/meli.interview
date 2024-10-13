using Meli.Interview.Domain.Core.Interfaces.Mapping;
using System.Linq.Expressions;


namespace Meli.Interview.Infra.Data.Mappings.Tables
{
    // TODO: Finalizar implementação de Table e implementar IColumn
    public class Table : ITable
    {
        public string PhysicalName { get; }

        public string Prefix => throw new NotImplementedException();
        public virtual Type? EntityType => null;

        public Table(string physicalName)
            => PhysicalName = physicalName ?? throw new ArgumentNullException(nameof(physicalName));
    }

    public sealed class Table<T> : Table, ITable<T>
    {
        public override Type EntityType => typeof(T);

        public Table(string physicalName) : base(physicalName) { }

        public IColumn<TProperty>? GetColumn<TProperty>(Expression<Func<T, TProperty>> prop)
            => throw new NotImplementedException();
    }
}
