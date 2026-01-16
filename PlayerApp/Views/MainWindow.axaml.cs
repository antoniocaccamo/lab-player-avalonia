using System;
using System.Collections.Generic;
using System.Reactive.Disposables.Fluent;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using PlayerApp.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;

namespace PlayerApp.Views
{
    public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        private LinkedList<ScreenWindow> _screenWindows = new LinkedList<ScreenWindow>();
        
        public MainWindow()
        {
            this.WhenActivated(disposables =>
            {

                this.Bind(ViewModel, vm => vm.Width, v => v.Width)
                    .DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.Heigth, v => v.Height)
                    .DisposeWith(disposables);
                this.Bind(ViewModel, vm => vm.Position, v => v.Position)
                    .DisposeWith(disposables);
                /* Handle view activation etc. */

                foreach (var screenWindowViewModel in ViewModel!.ScreenViewModels)

                {
                    var win = new ScreenWindow
                    {
                        //SystemDecorations = SystemDecorations.None,
                        DataContext = screenWindowViewModel
                    };
                    win.Show();
                    _screenWindows.AddLast(win);
                }
                
                this.PositionChanged += (sender, args) => { this.ViewModel!.Position = this.Position; };
                this.Closing += (sender, args) =>
                {
                    foreach (var win in _screenWindows)
                        win.Close();
                };
            });
            AvaloniaXamlLoader.Load(this);
        }


        private void FileClose_OnClick(object? sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}