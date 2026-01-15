using System;
using PlayerApp.Models;
using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels;

public class ScreenSettingViewModel : ViewModelBase
{
    private readonly Screen _screen;

    private int _width;
    private int _height;
    private int _left;
    private int _top;

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
        _width = _screen.Size.Width;
        _height = _screen.Size.Height;
        _left = _screen.Location.X;
        _top = _screen.Location.Y;
        Locked = _screen.Id % 2 == 0;

        this.WhenAnyValue(vm => vm.Width)
            .Subscribe(w =>
            {
                _screen.Size.Width = w;
                Dump();
            });

        this.WhenAnyValue(vm => vm.Height)
            .Subscribe(h =>
            {
                _screen.Size.Height = h;
                Dump();
            });
        
        this.WhenAnyValue(vm => vm.Left)
            .Subscribe(h =>
            {
                _screen.Location.X = h;
                Dump();
            });
        
        this.WhenAnyValue(vm => vm.Top)
            .Subscribe(h =>
            {
                _screen.Location.Y = h;
                Dump();
            });
        
    }


    public string Title => $"Screen #{this._screen.Id + 1}";

    public int Width
    {
        get => _width;
        set => this.RaiseAndSetIfChanged(ref _width, value);
    }

    public int Height
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


    private void Dump()
    {
        this.Log().Info($"screen: {_screen}");
    }
}