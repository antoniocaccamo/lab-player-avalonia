using Avalonia.Markup.Xaml;
using PlayerApp.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace PlayerApp.Views;

public partial class ScreenSettingView : ReactiveUserControl<ScreenSettingViewModel>
{
    public ScreenSettingView()
    {
        this.WhenActivated(disposables =>
            {

            });
        AvaloniaXamlLoader.Load(this);
    }
}