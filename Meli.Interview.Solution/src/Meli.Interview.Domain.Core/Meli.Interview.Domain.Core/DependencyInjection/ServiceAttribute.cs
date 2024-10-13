using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meli.Interview.Domain.Core.DependencyInjection
{
    /// <summary>
    /// Classes que contém este atributo são detectadas e registradas
    /// automaticamente no sistmea de injeção de dependência.
    /// </summary>
    public class ServiceAttribute : Attribute
    {
        /// <summary>O tempo de vida do serviço registrado.</summary>
        public ServiceLifetime Lifetime { get; }

        public ServiceAttribute(ServiceLifetime lifetime)
            => Lifetime = lifetime;
    }
}
