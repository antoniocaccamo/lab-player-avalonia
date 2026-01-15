using Microsoft.Extensions.DependencyInjection;
using PlayerApp.Services.Configuration;
using PlayerApp.Services.Sequences;


namespace PlayerApp.Services;

public static class ServiceCollectionExtensions
{

    public static void AddCommonServices(this IServiceCollection collection)
    {
        collection.AddSingleton<ISequenceService, SequenceService>();
        collection.AddSingleton<IConfigurationService, ConfigurationService>();
    }

}