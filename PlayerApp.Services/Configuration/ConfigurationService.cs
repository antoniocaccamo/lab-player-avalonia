using PlayerApp.Models;

namespace PlayerApp.Services.Configuration;


public class ConfigurationService : IConfigurationService
{
    public Models.Configuration Read()
    {
        return Constants.DefaultConfiguration;
    }
}