using PlayerApp.Models;

namespace PlayerApp.Services.Configuration;


public class ConfigurationService : IConfigurationService
{
    
    private readonly Models.Configuration _config;

    public ConfigurationService()
    {
        _config = Constants.DefaultConfiguration;
    }
    

    public Models.Configuration Get()
    {
        return Constants.DefaultConfiguration;
    }
}