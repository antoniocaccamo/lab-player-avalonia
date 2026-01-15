using System.Reactive.Disposables;
using System.Reactive.Disposables.Fluent;
using ReactiveUI;
using Splat;

namespace PlayerApp.ViewModels
{
    public class ViewModelBase : ReactiveObject, IActivatableViewModel, IEnableLogger
    {
        public ViewModelActivator Activator { get; }

        protected ViewModelBase()
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
    }
}