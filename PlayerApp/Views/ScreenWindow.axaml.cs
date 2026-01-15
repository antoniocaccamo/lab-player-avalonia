using System.Reactive.Disposables.Fluent;
using Avalonia.Markup.Xaml;
using PlayerApp.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace PlayerApp.Views;

public partial class ScreenWindow : ReactiveWindow<ScreenViewModel>
{
    public ScreenWindow()
    {
        this.WhenActivated(disposables =>
        {
            this.Bind(ViewModel, vm => vm.Width, v => v.Width)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.Heigth, v => v.Height)
                .DisposeWith(disposables);
            this.Bind(ViewModel, vm => vm.Position, v => v.Position)
                .DisposeWith(disposables);
            this.PositionChanged += (sender, args) => { this.ViewModel!.Position = this.Position; };
        });
        AvaloniaXamlLoader.Load(this);
    }
}