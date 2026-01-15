using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using PlayerApp.ViewModels;
using ReactiveUI;
using ReactiveUI.Avalonia;
using Splat;

namespace PlayerApp.Views
{

    public partial class VideoPlayer : ReactiveUserControl<VideoPlayerViewModel>, IEnableLogger
    {
        public VideoPlayer()
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