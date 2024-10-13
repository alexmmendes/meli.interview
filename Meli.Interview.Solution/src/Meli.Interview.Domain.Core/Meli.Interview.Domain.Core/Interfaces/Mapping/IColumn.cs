using System;

namespace Meli.Interview.Domain.Core.Interfaces.Mapping
{
    /// <summary>Representa uma coluna de uma tabela mapeada do banco de dados.</summary>
    public interface IColumn
    {
        /// <summary>Nome físico desta coluna no banco de dados.</summary>
        string PhysicalName { get; }

        /// <summary>
        /// Tipo usado para mapear esta coluna no código.
        /// Pode ser <see langword="null" /> caso não haja uma classe no código
        /// que represente esta coluna.
        /// </summary>
        Type? PropertyType { get; }
    }

    /// <summary>Versão tipada de <see cref="IColumn" /> que representa uma propriedade específica no código.</summary>
    /// <typeparam name="T">Tipo da entidade representada por esta coluna.</typeparam>
    public interface IColumn<T>
    {
    }
}
