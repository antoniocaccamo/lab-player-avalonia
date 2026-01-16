using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using PlayerApp.ViewModels.Players;
using ReactiveUI;
using ReactiveUI.Avalonia;
using Splat;

namespace PlayerApp.Views.Players
{

    public partial class VideoPlayerView : ReactiveUserControl<VideoPlayerViewModel>, IEnableLogger
    {
        
        
        public VideoPlayerView()
        {
            this.WhenActivated(disposables =>
            {
                
            });
            AvaloniaXamlLoader.Load(this);
        }
        
        // private void OnDataContextChanged(object sender, EventArgs e)
        // {
        //     if (DataContext is MainWindowViewModel vm)
        //     {
        //         vm.Play();
        //     }
        // }

        private void VideoViewOnPointerEntered(object sender, PointerEventArgs e)
        {
            ControlsPanel.IsVisible = true;
        }

        private void VideoViewOnPointerExited(object sender, PointerEventArgs e)
        {
            ControlsPanel.IsVisible = false;
        }

        private void Control_OnSizeChanged(object? sender, SizeChangedEventArgs e)
        {
            string aspectRatio = $"{e.NewSize.Width}:{e.NewSize.Height}";
            this.Log().Info($"new aspectRatio: {aspectRatio}");
            this.ViewModel!.MediaPlayer.AspectRatio = aspectRatio;
        }
    }
}