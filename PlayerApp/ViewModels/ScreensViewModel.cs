using System.Collections.ObjectModel;
using DynamicData.Kernel;
using PlayerApp.Models;
using PlayerApp.Services.Configuration;
using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels;

public class ScreensViewModel : RoutableBaseViewModel
{
    private Configuration _config;
    private ObservableCollection<ScreenSettingViewModel> _screenViewModels = [] ;


    public ScreensViewModel(): base(Locator.Current.GetService<IScreen>()!)
    {
        IConfigurationService  configurationService = Locator.Current.GetService<IConfigurationService>()!;
        _config = configurationService.Get();
        _config.Screens.AsList()
            .ForEach(
                screen => _screenViewModels.Add(new ScreenSettingViewModel(screen))
            );
    }
    
    
    public ObservableCollection<ScreenSettingViewModel> ScreensViewModels
    {
        get => _screenViewModels;
        set => this.RaiseAndSetIfChanged(ref _screenViewModels, value);
    }
}