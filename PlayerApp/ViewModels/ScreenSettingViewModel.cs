using System;
using Avalonia;
using PlayerApp.Models;
using PlayerApp.ViewModels.Players;
using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels;

public partial class ScreenSettingViewModel : BaseViewModel
{
    private readonly Screen _screen;
    private int _width;
    private int _height;
    private int _left;
    private int _top;
    private PixelPoint _position;

    private PlayerBaseViewModel? _currentPlayer;
    
    public ScreenSettingViewModel()
    {
        _screen = Constants.DefaultScreen;
        
        Initialize();
    }

    public ScreenSettingViewModel(Screen screen)
    {
        this._screen = screen;
        Initialize();
    }

    private void Initialize()
    {
        this._width = _screen.Size.Width; 
        this._height = _screen.Size.Height;
        _left = _screen.Location.X;
        _top = _screen.Location.Y;
        Locked = _screen.Id % 2 == 0;
        this._position = new PixelPoint(_screen.Location.X, _screen.Location.Y);

        CurrentPlayer = new VideoPlayerViewModel();
        
        this.WhenAnyValue(vm => vm.Width)
            .Subscribe(w =>
            {
                _screen.Size.Width = w;
                Dump();
            });
        
        this.WhenAnyValue(vm => vm.Heigth)
            .Subscribe(h =>
            {
                _screen.Size.Height = h;
                Dump();
            });
        
        this.WhenAnyValue(vm => vm.Left)
            .Subscribe(h =>
            {
                _screen.Location.X = h;
                Position = new PixelPoint(_screen.Location.X, _screen.Location.Y); 
                Dump();
            });
        
        this.WhenAnyValue(vm => vm.Top)
            .Subscribe(h =>
            {
                _screen.Location.Y = h;
                Position = new PixelPoint(_screen.Location.X, _screen.Location.Y); 
                Dump();
            });
        
        this.WhenAnyValue(vm => vm.Position)
            .Subscribe(pos =>
            {
                _screen.Location.X = pos.X;
                _screen.Location.Y = pos.Y;
                Dump();
            });
    }
    
    private void Dump()
    {
        this.Log().Info($"screen: {_screen}");
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
    
    public int Left
    {
        get => _left;
        set => this.RaiseAndSetIfChanged(ref _left, value);
    }

    public int Top
    {
        get => _top;
        set => this.RaiseAndSetIfChanged(ref _top, value);
    }

    public bool Locked { get; set; }
    

    public PixelPoint Position
    {
        get =>_position; 
        set=>this.RaiseAndSetIfChanged(ref _position, value);
    }

    public string Greeting { get; } = "Welcome to Avalonia!";
    
    public string Title => $"Screen #{this._screen.Id + 1}";
    //public VideoPlayerViewModel VideoPlayerViewModel { get; private set; } = new();

    public PlayerBaseViewModel CurrentPlayer
    {
        get => _currentPlayer; 
        protected set => this.RaiseAndSetIfChanged(ref _currentPlayer, value);
    }
}
