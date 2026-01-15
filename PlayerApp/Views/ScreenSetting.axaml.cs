using Avalonia.Markup.Xaml;
using PlayerApp.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace PlayerApp.Views;

public partial class ScreenSetting : ReactiveUserControl<ScreenSettingViewModel>
{
    public ScreenSetting()
    {
        this.WhenActivated(disposables =>
            {

            });
        AvaloniaXamlLoader.Load(this);
    }
}