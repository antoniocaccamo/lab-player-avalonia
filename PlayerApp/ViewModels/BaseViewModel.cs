using System.Reactive.Disposables;
using System.Reactive.Disposables.Fluent;
using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels
{
    public class BaseViewModel : ReactiveObject, IActivatableViewModel, IRoutableViewModel, IEnableLogger
    {
        public ViewModelActivator Activator { get; }

        protected BaseViewModel()
        {
            Activator = new ViewModelActivator();
            this.WhenActivated((CompositeDisposable disposables) =>
            {
                /* handle activation */
                Disposable
                    .Create(() =>
                    {
                        /* handle deactivation */
                    })
                    .DisposeWith(disposables);
            });
        }

        public string? UrlPathSegment { get; } 
        public IScreen HostScreen { get; }
    }
}