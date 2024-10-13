using AutoMapper;
using Meli.Interview.Application.AutoMapper;
using Meli.Interview.Application.Interfaces.CentroDistribuicao;
using Meli.Interview.Application.Interfaces.Pedido;
using Meli.Interview.Application.Services;
using Meli.Interview.Domain.Core.DependencyInjection;
using Meli.Interview.Domain.Core.Interfaces.Mapping;
using Meli.Interview.Domain.Interfaces.Repository;
using Meli.Interview.Infra.Data.Context;
using Meli.Interview.Infra.Data.Mappings;
using Meli.Interview.Infra.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Reflection;

namespace Meli.Interview.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        /// <summary>Prefixo usado para filtrar assemblies que serão escaneadas.</summary>
        private const string AssemblyPrefix = "Meli.Interview";


        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {
            if (services is null)
                throw new ArgumentNullException(nameof(services));

            var baseAssemblies = new[]
            {
                Assembly.GetCallingAssembly()
            };

            RegisterManualServices(services, configuration);

            ScanAssemblies(services, baseAssemblies);
            RegisterManualServices(services, configuration);
            RegisterTables(services);
        }

        #region Assemblies
        /// <summary>
        /// Encontra todas as assemblies referenciadas por um conjunto de assemblies "base".
        /// Apenas assemblies que se encaixam em <see cref="AssemblyPrefix"/> são retornadas.
        /// </summary>
        /// <param name="baseAssemblies">As assemblies base para início da pesquisa.</param>
        private static IReadOnlyCollection<Assembly> FindAssemblies(IReadOnlyCollection<Assembly> baseAssemblies)
        {
            var visitedAssemblies = new HashSet<Assembly>();
            var visitedNames = new HashSet<string>();
            var nextNames = new Queue<AssemblyName>();

            foreach (var assembly in baseAssemblies)
                nextNames.Enqueue(assembly.GetName());

            while (nextNames.Count > 0)
            {
                var assemblyName = nextNames.Dequeue();

                if (assemblyName.Name is null || !assemblyName.Name.StartsWith(AssemblyPrefix, StringComparison.Ordinal))
                    continue;

                if (visitedNames.Contains(assemblyName.FullName))
                    continue;

                var assembly = Assembly.Load(assemblyName);

                visitedNames.Add(assemblyName.FullName);
                visitedAssemblies.Add(assembly);

                foreach (var referencedName in assembly.GetReferencedAssemblies())
                    nextNames.Enqueue(referencedName);
            }

            return visitedAssemblies;
        }

        /// <summary>Escaneia uma ou mais assemblies base e registra todos os serviços contidos nelas.</summary>
        /// <param name="services">A collection em que serviços serão registrados.</param>
        /// <param name="baseAssemblies">As assemblies base de início de pesquisa.</param>
        private static void ScanAssemblies(IServiceCollection services, IReadOnlyCollection<Assembly> baseAssemblies)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            if (services is null)
                throw new ArgumentNullException(nameof(services));

            var types = FindAssemblies(baseAssemblies)
                .SelectMany(a => a.GetTypes())
                .Select(t => (Type: t, Attribute: t.GetCustomAttribute<ServiceAttribute>()))
                .Where(t => t.Attribute != null);

            foreach (var (type, attribute) in types)
            {
                var lifetime = attribute!.Lifetime;

                if (type.IsGenericType)
                    RegisterGeneric(services, type, lifetime);
                else
                    RegisterNonGeneric(services, type, lifetime);
            }

            stopwatch.Stop();

        }
        private static void RegisterGeneric(IServiceCollection services, Type type, ServiceLifetime lifetime)
        {
            var genericDefinition = type.GetGenericTypeDefinition();
            var arguments = type.GetGenericArguments().ToImmutableHashSet();

            services.Add(new ServiceDescriptor(genericDefinition, genericDefinition, lifetime));

            foreach (var interfaceType in type.GetInterfaces())
            {
                if (!interfaceType.IsGenericType)
                    continue;

                var interfaceArguments = interfaceType.GetGenericArguments().ToImmutableHashSet();
                if (interfaceArguments.Except(arguments).Any())
                    continue;
                var genericInterfaceType = interfaceType.GetGenericTypeDefinition();


                services.Add(new ServiceDescriptor(
                    serviceType: genericInterfaceType,
                    implementationType: genericDefinition,
                    lifetime: lifetime
                ));
            }
        }

        private static void RegisterNonGeneric(IServiceCollection services, Type type, ServiceLifetime lifetime)
        {
            services.Add(new ServiceDescriptor(type, type, lifetime));

            foreach (var interfaceType in type.GetInterfaces())
            {
                services.Add(new ServiceDescriptor(
                    serviceType: interfaceType,
                    factory: p => p.GetRequiredService(type),
                    lifetime: lifetime
                ));
            }
        }


        #endregion

        #region RegisterManualServices
        private static void RegisterManualServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<AutoMapper.IConfigurationProvider>(sp => AutoMapperConfiguration.RegisterMappings());
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<AutoMapper.IConfigurationProvider>(), sp.GetService));


            services.AddDbContext<ExpressContext>(o => o
                .UseSqlServer(configuration.GetConnectionString("MeliInterviewConnectionString"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors());
            services.AddScoped<ICentroDistribuicaoService, CentroDistribuicaoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoService, PedidoService>();
            services.AddTransient<IPedidoRepository, PedidoRepository>();
        }
        #endregion

        #region RegisterTables
        private static void RegisterTables(IServiceCollection services)
        {
            services.AddSingleton<ITable>(PedidoMap.GenerateTable());

        }
        #endregion
    }
}
