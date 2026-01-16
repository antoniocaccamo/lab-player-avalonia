using System;
using ReactiveUI;

namespace PlayerApp.ViewModels.Players;

public class RoutablePlayerBaseViewModel : PlayerBaseViewModel, IRoutableViewModel
{
    
    public IScreen HostScreen { get; }

    // Unique identifier for the routable view model.
    public string UrlPathSegment { get; } = Guid.NewGuid().ToString().Substring(0, 5);

    
    public RoutablePlayerBaseViewModel(IScreen screen) => HostScreen = screen;
}