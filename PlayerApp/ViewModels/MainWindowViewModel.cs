using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Avalonia;
using Microsoft.Extensions.DependencyInjection;
using PlayerApp.Models;
using PlayerApp.Services.Configuration;
using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public string Greeting { get; } = "Welcome to Avalonia!";
    
    private Configuration _config;
    
    private int _width;
    private int _height;
    private PixelPoint _position;

    private readonly IConfigurationService _configurationService =
        App.ServiceProvider.GetRequiredService<IConfigurationService>();
    
    private ObservableCollection<ScreenViewModel> _screenViewModels = [];

    public MainWindowViewModel()
    {
        _configurationService =
            App.ServiceProvider.GetRequiredService<IConfigurationService>();
        this._config = _configurationService.Read();
        this._width = _config.Size.Width; 
        this._height = _config.Size.Height;
        this._position = new PixelPoint(_config.Location.X, _config.Location.Y);

        foreach (var screen in _config.Screens)
        {
            
            this._screenViewModels.Add(new ScreenViewModel(screen));
        }        

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

    public VideoPlayerViewModel VideoPlayerViewModel { get; private set; } = new();
    
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

    public ObservableCollection<ScreenViewModel> ScreenViewModels
    {
        get => _screenViewModels;
        set => this.RaiseAndSetIfChanged(ref _screenViewModels, value);
    }

    private void Dump()
    {
        this.Log().Info($"config: {_config}");
    }
}
