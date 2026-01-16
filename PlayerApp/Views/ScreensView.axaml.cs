using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PlayerApp.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace PlayerApp.Views;

public partial class ScreensView : ReactiveUserControl<ScreensViewModel>
{
    public ScreensView()
    {
        this.WhenActivated(disposables => { });
        AvaloniaXamlLoader.Load(this);
    }
}