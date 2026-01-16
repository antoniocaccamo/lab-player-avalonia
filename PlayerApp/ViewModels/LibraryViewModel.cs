using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels;

public class LibraryViewModel : RoutableBaseViewModel
{
    public LibraryViewModel() : base(Locator.Current.GetService<IScreen>()!) 
    {
    }
}