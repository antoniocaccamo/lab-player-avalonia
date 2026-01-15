using System;
using Avalonia.Controls;
using LibVLCSharp.Shared;
using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels;

public class VideoPlayerViewModel : ViewModelBase, IDisposable
{
    private readonly LibVLC _libVlc;
    private readonly MediaPlayer _mediaPlayer;
    private readonly Media _media;
    private double _progress = 0L;

    public VideoPlayerViewModel()
    {
        this._libVlc = new LibVLC(enableDebugLogs: false);
        this._mediaPlayer = new MediaPlayer(_libVlc);
        this._mediaPlayer.Mute = true;
        
        this._mediaPlayer.TimeChanged += (sender, args) =>
        {
            Progress = 100 * (double)args.Time / (double)_media?.Duration!;
            this.Log().Info($" time: {Progress} duration: {_media?.Duration ?? 0}");
        };

        this._media = new Media(_libVlc,
            // new Uri("https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")
            // new Uri(@"/Users/antonio.caccamo/Movies/153976-817104245_small.mp4")
            new Uri(@"/Users/antonio.caccamo/Workspaces/me/fatjon/CBT Nuggets F5 BIG-IP Local Traffic Manager/19 - iRules.mp4")
            );

        this._media.StateChanged += (sender, args) =>
        {
            this.Log().Info($" Media State Changed: {args.State} {args.ToString()}");
        };
    }

    public string Greeting { get; } = "Welcome to Avalonia!";

    public MediaPlayer MediaPlayer => this._mediaPlayer;

    public double Progress
    {
        get => _progress;
        set => this.RaiseAndSetIfChanged(ref _progress, value);
    }



    public void Play()
    {
        if (Design.IsDesignMode)
        {
            return;
        }

        try
        {
            //this._mediaPlayer.Media = this._media;
            this._mediaPlayer.Play(_media);
        }
        catch (Exception e)
        {
            this.Log().Error("error occurred", e);
            throw;
        }
    }

    public void Stop()
    {
        this._mediaPlayer.Stop();
        this.Progress = 0L;
    }

    public void Dispose()
    {
        _libVlc.Dispose();
        _mediaPlayer.Dispose();
    }

}