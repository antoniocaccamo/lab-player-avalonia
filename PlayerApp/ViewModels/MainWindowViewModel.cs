using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Reactive;
using Avalonia;
//using Microsoft.Extensions.DependencyInjection;
using PlayerApp.Models;
using PlayerApp.Services.Configuration;
using PlayerApp.ViewModels.Players;
using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels;

public partial class MainWindowViewModel : BaseViewModel, IScreen
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    private Configuration _config;
    
    private int _width;
    private int _height;
    private PixelPoint _position;
    
    
    //private ScreensViewModel _screensViewModel ;
    private BaseViewModel _currentViewModel;

    private readonly IConfigurationService _configurationService 
        //= App.ServiceProvider.GetRequiredService<IConfigurationService>();
        ;
    
    private ObservableCollection<ScreenSettingViewModel> _screenViewModels = [];
    
    public RoutingState Router { get; } = new ();

    public MainWindowViewModel()
    {
        _configurationService = Locator.Current.GetService<IConfigurationService>()!;
        this._config = _configurationService.Get();
        this._width = _config.Size.Width; 
        this._height = _config.Size.Height;
        this._position = new PixelPoint(_config.Location.X, _config.Location.Y);
        
       
        //_screensViewModel = new ScreensViewModel();
       
        

        foreach (var screen in _config.Screens)
        {
            
            this._screenViewModels.Add(new ScreenSettingViewModel(screen));
        }

        ShowScreensSettingCommand = ReactiveCommand.Create(() =>
        {
            this.Log().Info("Show screens settings");
            var routable = Locator.Current.GetService<ScreensViewModel>()!;
            GoTo(routable);
        });
        
        ShowLibraryCommand = ReactiveCommand.Create(() =>
        {
            this.Log().Info("Show library");
            var routable = Locator.Current.GetService<LibraryViewModel>()!;
            GoTo(routable);
        });

        

        this.WhenAnyValue(vm => vm.Width)
            .Subscribe(w =>
            {
                _config.Size.Width = w;
                Dump();
            });
        
        this.WhenAnyValue(vm => vm.Heigth)
            .Subscribe(h =>
            {
                _config.Size.Height = h;
                Dump();
            });
        
        this.WhenAnyValue(vm => vm.Position)
            .Subscribe(pos =>
            {
                _config.Location.X = pos.X;
                _config.Location.Y = pos.Y;
                Dump();
            });
        
        
    }

    private void GoTo(RoutableBaseViewModel routable)
    {
        Router.Navigate.Execute(routable)
            .Subscribe(
                    
            );
    }



    public int Width {
        get => _width;
        set => this.RaiseAndSetIfChanged(ref _width, value);
    }

    public int Heigth
    {
        get => _height;
        set => this.RaiseAndSetIfChanged(ref _height, value);
    }

    public PixelPoint Position
    {
        get =>_position; 
        set=>this.RaiseAndSetIfChanged(ref _position, value);
    }

    public ObservableCollection<ScreenSettingViewModel> ScreenViewModels
    {
        get => _screenViewModels;
        set => this.RaiseAndSetIfChanged(ref _screenViewModels, value);
    }


    public BaseViewModel CurrentViewModel
    {
        get => _currentViewModel;
        set => this.RaiseAndSetIfChanged(ref _currentViewModel, value);
    }

    public ReactiveCommand<Unit, Unit> ShowScreensSettingCommand { get; }
    
    public ReactiveCommand<Unit, Unit> ShowLibraryCommand { get; }
    
    public RoutableBaseViewModel ScreensViewModel  => Locator.Current.GetService<ScreensViewModel>()!;

    //public ReactiveCommand<string,Unit> ShowCommand { get; }

    private void Dump()
    {
        this.Log().Info($"config: {_config}");
    }
    
    
}
