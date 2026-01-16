using System;
using ReactiveUI;

namespace PlayerApp.ViewModels.Players;

public class RoutableBaseViewModel : BaseViewModel, IRoutableViewModel
{
    
    public IScreen HostScreen { get; }

    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    
    public RoutableBaseViewModel(IScreen screen) => HostScreen = screen;
}