//using Microsoft.Extensions.DependencyInjection;
using PlayerApp.Services.Configuration;
using PlayerApp.Services.Sequences;
using Splat;

namespace PlayerApp.Services;

public static class ServiceCollectionExtensions
{

    // public static void AddCommonServices(this IServiceCollection collection)
    // {
    //     
    //     Locator.
    //     collection.AddSingleton<ISequenceService, SequenceService>();
    //     collection.AddSingleton<IConfigurationService, ConfigurationService>();
    // }
    
    public static void AddCommonServices()
    {
        var logger = new ConsoleLogger();
        Locator.CurrentMutable.RegisterLazySingleton( () =>  logger, typeof(ILogger));
        Locator.CurrentMutable.RegisterLazySingleton(() => new SequenceService(), typeof(ISequenceService));
        Locator.CurrentMutable.RegisterLazySingleton(() => new ConfigurationService(), typeof(IConfigurationService));
    }

}