using System;
using Microsoft.Extensions.DependencyInjection;


namespace Meli.Interview.Domain.Core.DependencyInjection
{
    /// <summary>
    /// Classes que contém este atributo são detectadas e registradas
    /// automaticamente no sistmea de injeção de dependência utilizando
    /// o tempo de vida 'Scoped'.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class ScopedServiceAttribute : ServiceAttribute
    {
        public ScopedServiceAttribute() : base(ServiceLifetime.Scoped) { }
    }
}
