using Microsoft.Extensions.DependencyInjection;

namespace Meli.Interview.Domain.Core.DependencyInjection
{
    /// <summary>
    /// Classes que contém este atributo são detectadas e registradas
    /// automaticamente no sistmea de injeção de dependência utilizando
    /// o tempo de vida 'Singleton'.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class SingletonServiceAttribute : ServiceAttribute
    {
        public SingletonServiceAttribute() : base(ServiceLifetime.Singleton) { }
    }
}
