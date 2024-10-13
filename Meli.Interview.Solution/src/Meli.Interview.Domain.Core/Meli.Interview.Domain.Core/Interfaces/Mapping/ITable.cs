using System.Linq.Expressions;

namespace Meli.Interview.Domain.Core.Interfaces.Mapping
{
    /// <summary>
    /// Representa uma tabela mapeada de banco de dados, que
    /// pode conter várias colunas.
    /// </summary>
    public interface ITable
    {
        /// <summary>Prefixo aplicado ao nome da tabela e a todas as suas colunas.</summary>
        string Prefix { get; }

        /// <summary>Nome físico desta tabela no banco de dados.</summary>
        string PhysicalName { get; }

        /// <summary>
        /// Tipo da entidade usada para mapear esta tabela no código.
        /// Pode ser <see langword="null" /> caso não haja uma classe no código
        /// que represente esta tabela.
        /// </summary>
        Type? EntityType { get; }
    }

    /// <summary>Versão tipada de <see cref="ITable" /> que representa uma entidade específica no código.</summary>
    /// <typeparam name="T">Tipo da entidade representada por esta tabela.</typeparam>
    public interface ITable<TEntity> : ITable
    {
        /// <summary>Obtém a coluna que representa o mapeamento de uma propriedade.</summary>
        /// <typeparam name="TProperty">Tipo da propriedade.</typeparam>
        /// <param name="prop">Expressão que seleciona a propriedade.</param>
        IColumn<TProperty>? GetColumn<TProperty>(Expression<Func<TEntity, TProperty>> prop);
    }
}
